// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

type SaveServiceOptions struct {
	// AzureRestAPISpecsGitSHA specifies the Git Commit SHA that these API Definitions were imported from.
	AzureRestAPISpecsGitSHA *string

	// OutputDirectory specifies the directory where the API Definitions should be written to.
	// This is the path to the `./api-definitions` directory.
	OutputDirectory string

	// ResourceProvider optionally specifies the Azure Resource Provider associated with this Service.
	// This is only present when SourceDataType is ResourceManagerSourceDataType.
	ResourceProvider *string

	// Service specifies details about this Service, including the available APIVersions.
	Service models.Service

	// ServiceName specifies the name of this Service (e.g. `Compute`).
	ServiceName string

	// SourceDataOrigin specifies the origin of this set of source data (e.g. AzureRestAPISpecsSourceDataOrigin).
	SourceDataOrigin models.SourceDataOrigin

	// SourceDataType specifies the type of the source data (e.g. ResourceManagerSourceDataType).
	SourceDataType models.SourceDataType
}

// SaveService persists the API Definitions for the Service specified in opts.
func SaveService(opts SaveServiceOptions) error {
	logging.Log.Info(fmt.Sprintf("Processing Service %q", opts.ServiceName))

	stages := []generatorStage{
		generateMetaDataStage{
			gitRevision:      opts.AzureRestAPISpecsGitSHA,
			sourceDataOrigin: opts.SourceDataOrigin,
			sourceDataType:   opts.SourceDataType,
		},
		generateServiceDefinitionStage{
			serviceName:         opts.ServiceName,
			resourceProvider:    opts.ResourceProvider,
			shouldGenerate:      true,
			terraformDefinition: opts.Service.TerraformDefinition,
		},
	}

	for apiVersion, apiVersionDetails := range opts.Service.APIVersions {
		logging.Log.Info(fmt.Sprintf("Processing Service %q / API Version %q..", opts.ServiceName, apiVersion))
		stages = append(stages, generateAPIVersionStage{
			serviceName:      opts.ServiceName,
			apiVersion:       apiVersion,
			isPreviewVersion: apiVersionDetails.Preview,
			resources:        apiVersionDetails.Resources,
			sourceDataOrigin: apiVersionDetails.Source,
			shouldGenerate:   true,
		})

		for apiResourceName, apiResourceDetails := range apiVersionDetails.Resources {
			// Output the API Definitions for this APIResource

			stages = append(stages, generateConstantStage{
				serviceName: opts.ServiceName,
				apiVersion:  apiVersion,
				apiResource: apiResourceName,
				constants:   apiResourceDetails.Constants,
				resourceIDs: apiResourceDetails.ResourceIDs,
			})

			stages = append(stages, generateModelsStage{
				serviceName: opts.ServiceName,
				apiVersion:  apiVersion,
				apiResource: apiResourceName,
				constants:   apiResourceDetails.Constants,
				models:      apiResourceDetails.Models,
			})

			stages = append(stages, generateOperationsStage{
				serviceName: opts.ServiceName,
				apiVersion:  apiVersion,
				apiResource: apiResourceName,
				constants:   apiResourceDetails.Constants,
				models:      apiResourceDetails.Models,
				operations:  apiResourceDetails.Operations,
			})

			stages = append(stages, generateResourceIDsStage{
				serviceName: opts.ServiceName,
				apiVersion:  apiVersion,
				apiResource: apiResourceName,
				resourceIDs: apiResourceDetails.ResourceIDs,
			})
		}
	}

	// Output the Terraform Resource Definitions, if they exist.
	if opts.Service.TerraformDefinition != nil {
		for terraformResourceLabel, terraformResourceDefinition := range opts.Service.TerraformDefinition.Resources {
			stages = append(stages, generateTerraformResourceDefinitionStage{
				serviceName:     opts.ServiceName,
				resourceLabel:   terraformResourceLabel,
				resourceDetails: terraformResourceDefinition,
			})

			stages = append(stages, generateTerraformSchemaModelsStage{
				serviceName:     opts.ServiceName,
				resourceDetails: terraformResourceDefinition,
			})

			stages = append(stages, generateTerraformMappingsDefinitionStage{
				serviceName:     opts.ServiceName,
				resourceDetails: terraformResourceDefinition,
			})

			stages = append(stages, generateTerraformResourceTestsStage{
				serviceName:     opts.ServiceName,
				resourceDetails: terraformResourceDefinition,
			})
		}
	}

	fs := newFileSystem()

	logging.Log.Debug("Running stages..")
	for _, stage := range stages {
		logging.Log.Trace(fmt.Sprintf("Processing Stage %q", stage.name()))
		if err := stage.generate(fs); err != nil {
			return fmt.Errorf("running stage %q: %+v", stage.name(), err)
		}
	}

	logging.Log.Debug("Persisting files to disk..")
	if err := persistFileSystem(opts.OutputDirectory, opts.SourceDataType, opts.ServiceName, fs); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
