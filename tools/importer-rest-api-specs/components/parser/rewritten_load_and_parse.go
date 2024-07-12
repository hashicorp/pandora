// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"sort"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/combine"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/dataworkarounds"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func LoadAndParseFiles(directory string, fileNames []string, serviceName, apiVersion string, resourceProvider *string) (*sdkModels.APIVersion, error) {
	// Some Services have been deprecated or should otherwise be ignored - check before proceeding
	if ignore.Services(serviceName) {
		logging.Debugf("Service %q should be ignored - skipping", serviceName)
		return nil, nil
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

		parsedResourceIds, err := swaggerFile.ParseResourceIds()
		if err != nil {
			return nil, fmt.Errorf("parsing Resource Ids from %q (Service %q / Api Version %q): %+v", file, serviceName, apiVersion, err)
		}
		if err := resourceIdResult.Append(*parsedResourceIds); err != nil {
			return nil, fmt.Errorf("appending Resource Ids: %+v", err)
		}
	}

	// TODO: Update this to be `parsedAPIVersion`
	parsed := make(map[string]importerModels.AzureApiDefinition)
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

	results := make(map[string]sdkModels.APIVersion)
	for _, service := range out {
		tempAPIVersion := &sdkModels.APIVersion{
			APIVersion: service.ApiVersion,
			Generate:   true,
			Preview:    service.IsPreviewVersion(),
			Resources:  service.Resources,
			Source:     sdkModels.AzureRestAPISpecsSourceDataOrigin,
		}
		if existing, hasExisting := results[service.ApiVersion]; hasExisting {
			tempAPIVersion = &existing
		}
		tempAPIVersion, err := dataworkarounds.Apply(service.ServiceName, *tempAPIVersion)
		if err != nil {
			return nil, fmt.Errorf("applying Swagger overrides: %+v", err)
		}

		results[service.ApiVersion] = *tempAPIVersion
	}

	keys := keysForMap(results)
	if len(keys) == 0 {
		// possible there's no data for this API Version
		return nil, nil
	}
	if len(results) > 1 {
		// we're parsing a single API Version out, so if there's multiple that'd be unexpected/a bug
		return nil, fmt.Errorf("expected a single API Version but got: %+v", keys)
	}

	result := results[keys[0]]
	// finally, now that we've parsed everything out, iterate over to cleanup any unused items
	result = cleanup.RemoveUnusedItems(result)
	return &result, nil
}

func keysForMap(input map[string]sdkModels.APIVersion) []string {
	keys := make(map[string]struct{})
	for k := range input {
		keys[k] = struct{}{}
	}
	// sort for consistency
	output := make([]string, 0)
	for k := range keys {
		output = append(output, k)
	}
	sort.Strings(output)
	return output
}

func keyForAzureApiDefinition(input importerModels.AzureApiDefinition) string {
	return fmt.Sprintf("%s-%s", input.ServiceName, input.ApiVersion)
}
