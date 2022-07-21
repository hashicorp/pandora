package parser

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/resourceids"

	"github.com/hashicorp/go-hclog"
)

func LoadAndParseFiles(directory string, fileNames []string, serviceName, apiVersion string, logger hclog.Logger) (*models.ParsedData, error) {
	// Some Services have been deprecated or should otherwise be ignored - check before proceeding
	if serviceShouldBeIgnored(serviceName) {
		logger.Debug(fmt.Sprintf("Service %q should be ignored - skipping", serviceName))

		return &models.ParsedData{}, nil
	}

	// First go through and parse all of the Resource ID's across all of the files
	// this means that the names which are generated are unique across the Service
	// which means these won't conflict and ultimately enables #44 (aliasing) in
	// the future.
	resourceIdResult := &resourceids.ParseResult{}
	for _, file := range fileNames {
		swaggerFile, err := load(directory, file, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing file %q: %+v", file, err)
		}

		parsedResourceIds, err := swaggerFile.ParseResourceIds()
		if err != nil {
			return nil, fmt.Errorf("parsing Resource Ids from %q (Service %q / Api Version %q): %+v", file, serviceName, apiVersion, err)
		}
		if err := resourceIdResult.Append(*parsedResourceIds, logger); err != nil {
			return nil, fmt.Errorf("appending Resource Ids: %+v", err)
		}
	}

	parsed := make(map[string]models.ParsedData, 0)
	for _, file := range fileNames {
		swaggerFile, err := load(directory, file, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing file %q: %+v", file, err)
		}

		definition, err := swaggerFile.parse(serviceName, apiVersion, *resourceIdResult)
		if err != nil {
			return nil, fmt.Errorf("parsing definition: %+v", err)
		}

		data := models.ParsedData{
			ServiceName: definition.ServiceName,
			ApiVersion:  definition.ApiVersion,
			Resources:   definition.Resources,
		}

		if existing, ok := parsed[data.Key()]; ok {
			// it's possible for Swagger tags to exist in multiple files, as EventHubs has DeleteAuthorizationRule which
			// lives in the AuthorizationRule json, but is technically part of the EventHubs namespace - as such we need
			// to combine the items rather than overwriting the key
			resources, err := combineResourcesWith(data, existing.Resources)
			if err != nil {
				return nil, fmt.Errorf("combining resources for %q: %+v", existing.Key(), err)
			}
			data.Resources = *resources
		}

		parsed[data.Key()] = data
	}

	out := make([]models.ParsedData, 0)
	for _, v := range parsed {
		// the Data API expects that an API Version will contain at least 1 Resource - avoid bad data here
		if len(v.Resources) == 0 {
			logger.Info(fmt.Sprintf("Service %q / Api Version %q contains no resources, skipping.", v.ServiceName, v.ApiVersion))
			continue
		}

		out = append(out, v)
	}

	if len(out) > 1 {
		return nil, fmt.Errorf("internal-error:the Swagger files for Service %q / API Version %q contained multiple resources (%d total)", serviceName, apiVersion, len(out))
	}

	if len(out) == 1 {
		return &out[0], nil
	}

	return nil, nil
}

func serviceShouldBeIgnored(name string) bool {
	servicesToIgnore := []string{
		"ADHybridHealthService", // TODO: is this EOL? Contains a Constant of an empty string: https://github.com/Azure/azure-rest-api-specs/blob/3eaa729b3686f20817145e771a8ab707c739dbbd/specification/adhybridhealthservice/resource-manager/Microsoft.ADHybridHealthService/stable/2014-01-01/ADHybridHealthService.json#L460-L471
		"Blockchain",            // EOL - https://github.com/Azure-Samples/blockchain/blob/1b712d6d05cca8da17bdd1894de8c3d25905685d/abs/migration-guide.md
		"DevSpaces",             // EOL - https://azure.microsoft.com/en-us/updates/azure-dev-spaces-is-retiring-on-31-october-2023/
		"DynamicsTelemetry",     // Fake RP - https://github.com/Azure/azure-rest-api-specs/pull/5161#issuecomment-486705231
		"IoTSpaces",             // EOL - https://github.com/Azure/azure-rest-api-specs/pull/13993
		"ServiceFabricMesh",     // EOL - https://azure.microsoft.com/en-us/updates/azure-service-fabric-mesh-preview-retirement/
	}
	for _, v := range servicesToIgnore {
		if strings.EqualFold(name, v) {
			return true
		}
	}
	return false
}
