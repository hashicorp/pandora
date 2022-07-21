package pipeline

import (
	"fmt"
	"log"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"
)

func parseAndOutputSegments(input RunInput) error {
	input.Logger.Debug("[STAGE] Parsing Swagger Files..")
	specificationsDirectory := filepath.Join(input.SwaggerDirectory, "specification")
	resourceManagerServices, err := parser.FindResourceManagerServices(specificationsDirectory, input.Logger)
	if err != nil {
		return fmt.Errorf("retrieving Resource Manager Service details from %q: %+v", specificationsDirectory, err)
	}

	services := make([]ServiceInput, 0)
	input.Logger.Debug("[STAGE] Processing Resource Manager Services..")
	for serviceName, service := range *resourceManagerServices {
		input.Logger.Trace(fmt.Sprintf("Processing Service %q..", serviceName))

		// pick only the latest for now, but leaving the logic below since we'll check all versions too soon
		sortedVersions := make([]string, 0)
		for version := range service.ApiVersionPaths {
			sortedVersions = append(sortedVersions, version)
		}
		sort.Strings(sortedVersions)
		if len(sortedVersions) > 0 {
			sortedVersions = []string{
				sortedVersions[len(sortedVersions)-1],
			}
		}

		for apiVersion, version := range sortedVersions {
			input.Logger.Trace(fmt.Sprintf("Identifying Swagger files within API Version %q for Service %q..", apiVersion, serviceName))
			versionPath := service.ApiVersionPaths[version]
			versionDirectory := filepath.Join(input.SwaggerDirectory + "/specification/" + versionPath)
			filesForVersion := make([]string, 0)
			filesInDirectory, err := parser.SwaggerFilesInDirectory(versionDirectory)
			if err != nil {
				return fmt.Errorf("details for the Version %q of Service %q were not found - does it exist on disk?", version, service.Name)
			}

			for _, file := range *filesInDirectory {
				fileWithoutPrefix := strings.TrimPrefix(file, versionDirectory)
				filesForVersion = append(filesForVersion, fileWithoutPrefix)
			}

			resourceManagerService := ResourceManagerServiceInput{
				ServiceName:      service.Name,
				ApiVersion:       version,
				ResourceProvider: service.ResourceProvider,
				SwaggerDirectory: versionDirectory,
				SwaggerFiles:     filesForVersion,
			}
			services = append(services, resourceManagerService.ToRunInput())
		}
	}

	fixedSegmentValues := make(map[string]struct{}, 0)
	for _, service := range services {
		input.Logger.Trace(fmt.Sprintf("Parsing Swagger files within API Version %q for Service %q..", service.ApiVersion, service.ServiceName))
		data, err := parseSwaggerFiles(service, input.Logger)
		if err != nil {
			log.Printf("❌ Service %q - Api Version %q", service.ServiceName, service.ApiVersion)
			log.Printf("     💥 Error: parsing Swagger files: %+v", err)
			return err
		}
		if data == nil {
			log.Printf("😵 Service %q / Api Version %q contains no resources, skipping.", service.ServiceName, service.ApiVersion)
			continue
		}

		for _, resource := range data.Resources {
			for _, id := range resource.ResourceIds {
				for _, segment := range id.Segments {
					if segment.FixedValue == nil {
						continue
					}

					input.Logger.Trace(fmt.Sprintf("Found Resource ID Segment %q..", *segment.FixedValue))
					fixedSegmentValues[*segment.FixedValue] = struct{}{}
				}
			}
		}
	}

	segments := make([]string, 0)
	for k := range fixedSegmentValues {
		segments = append(segments, k)
	}
	sort.Strings(segments)

	fmt.Println("[DEBUG] ---------------------------------------------")
	fmt.Println("[DEBUG] ---------------------------------------------")

	for _, v := range segments {
		fmt.Println(v)
	}

	fmt.Println("[DEBUG] ---------------------------------------------")
	fmt.Println("[DEBUG] ---------------------------------------------")

	return nil
}
