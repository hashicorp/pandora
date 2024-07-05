// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/dataworkarounds"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/combine"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func LoadAndParseFiles(directory string, fileNames []string, serviceName, apiVersion string, resourceProvider *string) (*importerModels.AzureApiDefinition, error) {
	// Some Services have been deprecated or should otherwise be ignored - check before proceeding
	if ignore.Services(serviceName) {
		logging.Debugf("Service %q should be ignored - skipping", serviceName)
		return &importerModels.AzureApiDefinition{}, nil
	}

	// First go through and parse all of the Resource ID's across all of the files
	// this means that the names which are generated are unique across the Service
	// which means these won't conflict and ultimately enables #44 (aliasing) in
	// the future.
	resourceIdResult := &resourceids.ParseResult{}
	var file2Swagger = make(map[string]*SwaggerDefinition, len(fileNames))
	for _, file := range fileNames {
		swaggerFile, err := load(directory, file)
		if err != nil {
			return nil, fmt.Errorf("parsing file %q: %+v", file, err)
		}
		file2Swagger[file] = swaggerFile

		parsedResourceIds, err := swaggerFile.ParseResourceIds(resourceProvider)
		if err != nil {
			return nil, fmt.Errorf("parsing Resource Ids from %q (Service %q / Api Version %q): %+v", file, serviceName, apiVersion, err)
		}
		if err := resourceIdResult.Append(*parsedResourceIds); err != nil {
			return nil, fmt.Errorf("appending Resource Ids: %+v", err)
		}
	}

	parsed := make(map[string]importerModels.AzureApiDefinition, 0)
	for _, file := range fileNames {
		swaggerFile := file2Swagger[file]

		definition, err := swaggerFile.parse(serviceName, apiVersion, resourceProvider, *resourceIdResult)
		if err != nil {
			return nil, fmt.Errorf("parsing definition: %+v", err)
		}

		data := importerModels.AzureApiDefinition{
			ServiceName: definition.ServiceName,
			ApiVersion:  definition.ApiVersion,
			Resources:   definition.Resources,
		}
		key := keyForAzureApiDefinition(data)

		if existing, ok := parsed[key]; ok {
			// it's possible for Swagger tags to exist in multiple files, as EventHubs has DeleteAuthorizationRule which
			// lives in the AuthorizationRule json, but is technically part of the EventHubs namespace - as such we need
			// to combine the items rather than overwriting the key
			resources, err := combine.ResourcesWith(data.Resources, existing.Resources)
			if err != nil {
				return nil, fmt.Errorf("combining resources for %q: %+v", key, err)
			}
			data.Resources = *resources
		}

		parsed[key] = data
	}

	out := make([]importerModels.AzureApiDefinition, 0)
	for _, v := range parsed {
		// the Data API expects that an API Version will contain at least 1 Resource - avoid bad data here
		if len(v.Resources) == 0 {
			logging.Infof("Service %q / Api Version %q contains no resources, skipping.", v.ServiceName, v.ApiVersion)
			continue
		}

		out = append(out, v)
	}

	logging.Tracef("Applying overrides to workaround invalid Swagger Definitions..")
	output, err := dataworkarounds.ApplyWorkarounds(out)
	if err != nil {
		return nil, fmt.Errorf("applying Swagger overrides: %+v", err)
	}

	out = *output

	for _, service := range out {
		// temporary shim to enable using the new logic
		version := sdkModels.APIVersion{
			APIVersion: service.ApiVersion,
			Generate:   true,
			Preview:    service.IsPreviewVersion(),
			Resources:  service.Resources,
			Source:     sdkModels.AzureRestAPISpecsSourceDataOrigin,
		}
		version = cleanup.RemoveUnusedItems(version)
		service.Resources = version.Resources
	}

	if len(out) > 1 {
		return nil, fmt.Errorf("internal-error:the Swagger files for Service %q / API Version %q contained multiple resources (%d total)", serviceName, apiVersion, len(out))
	}

	if len(out) == 1 {
		return &out[0], nil
	}

	return nil, nil
}

func keyForAzureApiDefinition(input importerModels.AzureApiDefinition) string {
	return fmt.Sprintf("%s-%s", input.ServiceName, input.ApiVersion)
}
