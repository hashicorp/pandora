// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func Run(input []importerModels.AzureApiDefinition, outputDirectory, swaggerGitSha string, resourceProvider, terraformServicePackage *string, logger hclog.Logger) error {
	sourceDataOrigin := models.AzureRestAPISpecsSourceDataOrigin
	sourceDataType := models.ResourceManagerSourceDataType
	serviceName := input[0].ServiceName
	logger.Info(fmt.Sprintf("Processing Service %q", serviceName))

	// TODO: remove this once the repository is consolidated since this should be inferrable
	terraformResourceNames := make([]string, 0)
	if terraformServicePackage != nil {
		for _, item := range input {
			for _, resource := range item.Resources {
				if resource.Terraform == nil {
					continue
				}

				for _, details := range resource.Terraform.Resources {
					terraformResourceNames = append(terraformResourceNames, details.ResourceName)
				}
			}
		}
	}

	stages := []generatorStage{
		generateMetaDataStage{
			gitRevision:      pointer.To(swaggerGitSha),
			sourceDataOrigin: sourceDataOrigin,
			sourceDataType:   sourceDataType,
		},
		generateServiceDefinitionStage{
			serviceName:                 serviceName,
			resourceProvider:            resourceProvider,
			shouldGenerate:              true,
			terraformServicePackageName: terraformServicePackage,
			terraformResourceNames:      terraformResourceNames,
		},
	}

	for _, serviceDetails := range input {
		logger.Info(fmt.Sprintf("Processing Service %q / API Version %q..", serviceDetails.ServiceName, serviceDetails.ApiVersion))
		stages = append(stages, generateAPIVersionStage{
			serviceName:      serviceDetails.ServiceName,
			apiVersion:       serviceDetails.ApiVersion,
			isPreviewVersion: serviceDetails.IsPreviewVersion(),
			resources:        serviceDetails.Resources,
			sourceDataOrigin: sourceDataOrigin,
			shouldGenerate:   true,
		})

		for apiResourceName, apiResourceDetails := range serviceDetails.Resources {
			// transform `models.AzureAPIResource` into the `resourcemanager` models so we have a consistent type
			// whilst this WILL change to the `data-api-sdk` models, we should standardise on `resourcemanager` first
			// so we have an easier migration path.
			input, err := transformer.ApiResourceFromModelResource(apiResourceDetails)
			if err != nil {
				return fmt.Errorf("transforming to APIResource: %+v", err)
			}

			// Output the API Definitions for this APIResource

			stages = append(stages, generateConstantStage{
				serviceName: serviceDetails.ServiceName,
				apiVersion:  serviceDetails.ApiVersion,
				apiResource: apiResourceName,
				constants:   input.Schema.Constants,
			})

			stages = append(stages, generateModelsStage{
				serviceName: serviceDetails.ServiceName,
				apiVersion:  serviceDetails.ApiVersion,
				apiResource: apiResourceName,
				constants:   input.Schema.Constants,
				models:      input.Schema.Models,
			})

			stages = append(stages, generateOperationsStage{
				serviceName: serviceDetails.ServiceName,
				apiVersion:  serviceDetails.ApiVersion,
				apiResource: apiResourceName,
				constants:   input.Schema.Constants,
				models:      input.Schema.Models,
				operations:  input.Operations.Operations,
			})

			stages = append(stages, generateResourceIDsStage{
				serviceName: serviceDetails.ServiceName,
				apiVersion:  serviceDetails.ApiVersion,
				apiResource: apiResourceName,
				resourceIDs: input.Schema.ResourceIds,
			})

			// Output the Terraform Resource Definitions, if they exist.
			// NOTE: this is going to want shifting around, but should stay here for now.
			if apiResourceDetails.Terraform != nil {
				for terraformResourceLabel, terraformResourceDefinition := range apiResourceDetails.Terraform.Resources {
					stages = append(stages, generateTerraformResourceDefinitionStage{
						serviceName:     serviceDetails.ServiceName,
						resourceLabel:   terraformResourceLabel,
						resourceDetails: terraformResourceDefinition,
					})

					stages = append(stages, generateTerraformSchemaModelsStage{
						serviceName:     serviceDetails.ServiceName,
						resourceDetails: terraformResourceDefinition,
					})

					stages = append(stages, generateTerraformMappingsDefinitionStage{
						serviceName:     serviceDetails.ServiceName,
						resourceDetails: terraformResourceDefinition,
					})

					stages = append(stages, generateTerraformResourceTestsStage{
						serviceName:     serviceDetails.ServiceName,
						resourceDetails: terraformResourceDefinition,
					})
				}
			}
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
