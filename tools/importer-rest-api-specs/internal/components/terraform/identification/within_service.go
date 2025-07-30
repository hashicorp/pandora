// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package identification

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	terraformModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

// WithinService identifies the Terraform Resources available within this Service, based on the terraformConfig
func WithinService(providerPrefix string, input sdkModels.Service, terraformConfig map[string]definitions.ResourceDefinition) (*terraformModels.WorkInProgressData, error) {
	output := terraformModels.WorkInProgressData{
		ProviderPrefix: providerPrefix,
		Resources:      make(map[string]terraformModels.WorkInProgressResource),
	}

	for resourceLabel, resourceMetaData := range terraformConfig {
		if resourceMetaData.ServiceName != input.Name {
			logging.Tracef("The Resource %q is for the Service %q but this is %q - skipping for now..", resourceLabel, resourceMetaData.ServiceName, input.Name)
			continue
		}

		logging.Infof("Processing the Terraform Resource %q..", resourceLabel)
		apiVersion, ok := input.APIVersions[resourceMetaData.APIVersion]
		if !ok {
			return nil, fmt.Errorf("the Resource %q referenced APIVersion %q which was not found", resourceLabel, resourceMetaData.APIVersion)
		}
		apiResource, ok := apiVersion.Resources[resourceMetaData.APIResource]
		if !ok {
			return nil, fmt.Errorf("the Resource %q referenced APIResource %q which was not found", resourceLabel, resourceMetaData.APIResource)
		}

		// find the name for this Resource ID
		var resourceIDName string
		for name, val := range apiResource.ResourceIDs {
			if val.ExampleValue == resourceMetaData.ID {
				resourceIDName = name
				break
			}
		}
		if resourceIDName == "" {
			return nil, fmt.Errorf("unable to identify the Resource ID associated with %q", resourceMetaData.ID)
		}

		methods, err := identifyMethodsForAPIResource(apiResource, resourceMetaData, resourceIDName)
		if err != nil {
			return nil, fmt.Errorf("identifying the methods Reosurce %q from the APIResource: %+v", resourceMetaData.Name, err)
		}

		resourceDefinition := buildResource(resourceIDName, resourceMetaData, *methods)
		if resourceDefinition == nil {
			logging.Trace("Resource Definition was nil - skipping")
			continue
		}

		// At this point in time we don't support Resources containing a Discriminated Type
		// We'd need to extend the Schema to support that (potentially generating one Resource per Implementation, etc)
		// It's doable, but wants design thought - particularly given Services like DataFactory which have hundreds of
		// implementations - which is why this is currently skipped.
		hasDiscriminatedType, err := containsDiscriminatedTypes(resourceDefinition, apiResource)
		if err != nil {
			return nil, fmt.Errorf("determining if the Resource Definition for %q contains Discriminated Types: %+v", resourceLabel, err)
		}
		if *hasDiscriminatedType {
			logging.Debugf("Resource %q is/contains a Discriminated Type - not supported at this time", resourceLabel)
			continue
		}

		output.Resources[resourceLabel] = terraformModels.WorkInProgressResource{
			APIResource: apiResource,
			InputData:   resourceMetaData,
			Resource:    *resourceDefinition,
		}
	}

	return &output, nil
}
