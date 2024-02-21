// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func Run(serviceName string, service models.Service, sourceDataOrigin models.SourceDataOrigin, sourceDataType models.SourceDataType, outputDirectory, swaggerGitSha string, resourceProvider *string, logger hclog.Logger) error {
	logger.Info(fmt.Sprintf("Processing Service %q", serviceName))

	stages := []generatorStage{
		generateMetaDataStage{
			gitRevision:      pointer.To(swaggerGitSha),
			sourceDataOrigin: sourceDataOrigin,
			sourceDataType:   sourceDataType,
		},
		generateServiceDefinitionStage{
			serviceName:         serviceName,
			resourceProvider:    resourceProvider,
			shouldGenerate:      true,
			terraformDefinition: service.TerraformDefinition,
		},
	}

	for apiVersion, apiVersionDetails := range service.APIVersions {
		logger.Info(fmt.Sprintf("Processing Service %q / API Version %q..", serviceName, apiVersion))
		stages = append(stages, generateAPIVersionStage{
			serviceName:      serviceName,
			apiVersion:       apiVersion,
			isPreviewVersion: isPreviewVersion(apiVersion),
			resources:        apiVersionDetails.Resources,
			sourceDataOrigin: apiVersionDetails.Source,
			shouldGenerate:   true,
		})

		for apiResourceName, apiResourceDetails := range apiVersionDetails.Resources {
			// Output the API Definitions for this APIResource

			stages = append(stages, generateConstantStage{
				serviceName: serviceName,
				apiVersion:  apiVersion,
				apiResource: apiResourceName,
				constants:   apiResourceDetails.Constants,
			})

			stages = append(stages, generateModelsStage{
				serviceName: serviceName,
				apiVersion:  apiVersion,
				apiResource: apiResourceName,
				constants:   apiResourceDetails.Constants,
				models:      apiResourceDetails.Models,
			})

			stages = append(stages, generateOperationsStage{
				serviceName: serviceName,
				apiVersion:  apiVersion,
				apiResource: apiResourceName,
				constants:   apiResourceDetails.Constants,
				models:      apiResourceDetails.Models,
				operations:  apiResourceDetails.Operations,
			})

			stages = append(stages, generateResourceIDsStage{
				serviceName: serviceName,
				apiVersion:  apiVersion,
				apiResource: apiResourceName,
				resourceIDs: apiResourceDetails.ResourceIDs,
			})
		}
	}

	// Output the Terraform Resource Definitions, if they exist.
	if service.TerraformDefinition != nil {
		for terraformResourceLabel, terraformResourceDefinition := range service.TerraformDefinition.Resources {
			stages = append(stages, generateTerraformResourceDefinitionStage{
				serviceName:     serviceName,
				resourceLabel:   terraformResourceLabel,
				resourceDetails: terraformResourceDefinition,
			})

			stages = append(stages, generateTerraformSchemaModelsStage{
				serviceName:     serviceName,
				resourceDetails: terraformResourceDefinition,
			})

			stages = append(stages, generateTerraformMappingsDefinitionStage{
				serviceName:     serviceName,
				resourceDetails: terraformResourceDefinition,
			})

			stages = append(stages, generateTerraformResourceTestsStage{
				serviceName:     serviceName,
				resourceDetails: terraformResourceDefinition,
			})
		}
	}

	fs := newFileSystem()

	logger.Debug("Running stages..")
	for _, stage := range stages {
		logger.Trace(fmt.Sprintf("Processing Stage %q", stage.name()))
		if err := stage.generate(fs, logger); err != nil {
			return fmt.Errorf("running stage %q: %+v", stage.name(), err)
		}
	}

	logger.Debug("Persisting files to disk..")
	if err := persistFileSystem(outputDirectory, sourceDataType, serviceName, fs, logger); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}

func isPreviewVersion(input string) bool {
	lower := strings.ToLower(input)

	// handles preview, privatepreview and publicpreview
	if strings.Contains(lower, "preview") {
		return true
	}
	if strings.Contains(lower, "beta") {
		return true
	}
	if strings.Contains(lower, "alpha") {
		return true
	}

	return false
}
