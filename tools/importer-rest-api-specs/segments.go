package main

import (
	"fmt"
	"log"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func parseAndOutputSegments(swaggerDirectory string, debug bool) error {
	if debug {
		log.Printf("[STAGE] Parsing Swagger Files..")
	}

	specificationsDirectory := filepath.Join(swaggerDirectory, "specification")
	resourceManagerServices, err := parser.FindResourceManagerServices(specificationsDirectory, debug)
	if err != nil {
		return fmt.Errorf("retrieving Resource Manager Service details from %q: %+v", specificationsDirectory, err)
	}

	services := make([]RunInput, 0)
	for _, service := range *resourceManagerServices {
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

		for _, version := range sortedVersions {
			versionPath := service.ApiVersionPaths[version]
			versionDirectory := filepath.Join(swaggerDirectory + "/specification/" + versionPath)
			filesForVersion := make([]string, 0)
			filesInDirectory, err := parser.SwaggerFilesInDirectory(versionDirectory)
			if err != nil {
				return fmt.Errorf("details for the Version %q of Service %q were not found - does it exist on disk?", version, service.Name)
			}

			for _, file := range *filesInDirectory {
				fileWithoutPrefix := strings.TrimPrefix(file, versionDirectory)
				filesForVersion = append(filesForVersion, fileWithoutPrefix)
			}

			resourceManagerService := ResourceManagerInput{
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
	for _, input := range services {
		data, err := parseSwaggerFiles(input, debug)
		if err != nil {
			log.Printf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion)
			log.Printf("     💥 Error: parsing Swagger files: %+v", err)
			return err
		}
		if data == nil {
			log.Printf("😵 Service %q / Api Version %q contains no resources, skipping.", input.ServiceName, input.ApiVersion)
			continue
		}

		for _, resource := range data.Resources {
			for _, id := range resource.ResourceIds {
				for _, segment := range id.Segments {
					if segment.FixedValue == nil {
						continue
					}

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
