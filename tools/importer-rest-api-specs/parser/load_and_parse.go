package parser

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"log"
	"os"
	"strings"
)

func LoadAndParseFiles(directory string, fileNames []string, serviceName, apiVersion string, debugLogging bool) (*[]ParsedData, error) {
	// Some Services have been deprecated or should otherwise be ignored - check before proceeding
	if serviceShouldBeIgnored(serviceName) {
		if debugLogging {
			log.Printf("[DEBUG] Skipping service %q", serviceName)
		}

		return &[]ParsedData{}, nil
	}

	// First go through and parse all of the Resource ID's across all of the files
	// this means that the names which are generated are unique across the Service
	// which means these won't conflict and ultimately enables #44 (aliasing) in
	// the future.
	resourceIdResult := &resourceIdParseResult{}
	for _, file := range fileNames {
		swaggerFile, err := load(directory, file, debugLogging)
		if err != nil {
			return nil, fmt.Errorf("parsing file %q: %+v", file, err)
		}

		parsedResourceIds, err := swaggerFile.ParseResourceIds()
		if err != nil {
			return nil, fmt.Errorf("parsing Resource Ids from %q (Service %q / Api Version %q): %+v", file, serviceName, apiVersion, err)
		}
		resourceIdResult.append(*parsedResourceIds)
	}

	// conditionally output the Resource ID's to a file so that we can check if any segments require normalizing
	// useful, but off by default
	if featureflags.ShouldOutputResourceIdsToFile {
		writeToFile(resourceIdResult.resourceUrisToMetadata)
	}

	// finally once we've got all of the Swagger files we need to generate names for the Resource ID Parsers
	if debugLogging {
		log.Printf("[DEBUG] Generating Names for the Resource IDs..")
	}
	if err := resourceIdResult.generateNames(); err != nil {
		return nil, fmt.Errorf("generating names for the Resource IDs: %+v", err)
	}

	parsed := make(map[string]ParsedData, 0)
	for _, file := range fileNames {
		swaggerFile, err := load(directory, file, debugLogging)
		if err != nil {
			return nil, fmt.Errorf("parsing file %q: %+v", file, err)
		}

		definition, err := swaggerFile.parse(serviceName, apiVersion, *resourceIdResult)
		if err != nil {
			return nil, fmt.Errorf("parsing definition: %+v", err)
		}

		data := ParsedData{
			ServiceName: definition.ServiceName,
			ApiVersion:  definition.ApiVersion,
			Resources:   definition.Resources,
		}

		if existing, ok := parsed[data.Key()]; ok {
			// it's possible for Swagger tags to exist in multiple files, as EventHubs has DeleteAuthorizationRule which
			// lives in the AuthorizationRule json, but is technically part of the EventHubs namespace - as such we need
			// to combine the items rather than overwriting the key
			resources, err := data.combineResourcesWith(existing.Resources)
			if err != nil {
				return nil, fmt.Errorf("combining resources for %q: %+v", existing.Key(), err)
			}
			data.Resources = *resources
		}

		parsed[data.Key()] = data
	}

	out := make([]ParsedData, 0)
	for _, v := range parsed {
		// the Data API expects that an API Version will contain at least 1 Resource - avoid bad data here
		if len(v.Resources) == 0 {
			if debugLogging {
				log.Printf("[INFO] Service %q / Api Version %q contains no resources, skipping.", v.ServiceName, v.ApiVersion)
			}
			continue
		}

		out = append(out, v)
	}
	return &out, nil
}

func writeToFile(metadata map[string]resourceUriMetadata) {
	f, err := os.OpenFile("resource-ids.txt", os.O_APPEND|os.O_CREATE|os.O_WRONLY, 0644)
	if err != nil {
		return
	}
	defer f.Close()

	for _, uri := range metadata {
		if uri.resourceId == nil {
			continue
		}

		resourceManagerUri := uri.resourceId.String()
		f.Write([]byte(fmt.Sprintf("%s\n", resourceManagerUri)))
	}
}

func serviceShouldBeIgnored(name string) bool {
	servicesToIgnore := []string{
		"Blockchain",
		"DevSpaces",
		"ServiceFabricMesh",
	}
	for _, v := range servicesToIgnore {
		if strings.EqualFold(name, v) {
			return true
		}
	}
	return false
}
