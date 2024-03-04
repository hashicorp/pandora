// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/stages"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

type SaveServiceOptions struct {
	// AzureRestAPISpecsGitSHA specifies the Git Commit SHA that these API Definitions were imported from.
	AzureRestAPISpecsGitSHA *string

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
func (r repositoryImpl) SaveService(opts SaveServiceOptions) error {
	logging.Log.Info(fmt.Sprintf("Processing Service %q", opts.ServiceName))

	items := []stages.Stage{
		stages.MetaDataStage{
			GitRevision:      opts.AzureRestAPISpecsGitSHA,
			SourceDataOrigin: opts.SourceDataOrigin,
			SourceDataType:   opts.SourceDataType,
		},
		stages.ServiceDefinitionStage{
			ServiceName:         opts.ServiceName,
			ResourceProvider:    opts.ResourceProvider,
			ShouldGenerate:      true,
			TerraformDefinition: opts.Service.TerraformDefinition,
		},
	}

	for apiVersion, apiVersionDetails := range opts.Service.APIVersions {
		logging.Log.Info(fmt.Sprintf("Processing Service %q / API Version %q..", opts.ServiceName, apiVersion))
		items = append(items, stages.APIVersionStage{
			APIResources:     apiVersionDetails.Resources,
			APIVersion:       apiVersion,
			IsPreviewVersion: apiVersionDetails.Preview,
			ServiceName:      opts.ServiceName,
			SourceDataOrigin: apiVersionDetails.Source,
			ShouldGenerate:   true,
		})

		for apiResourceName, apiResourceDetails := range apiVersionDetails.Resources {
			// Output the API Definitions for this APIResource

			items = append(items, stages.ConstantStage{
				ServiceName: opts.ServiceName,
				APIVersion:  apiVersion,
				APIResource: apiResourceName,
				Constants:   apiResourceDetails.Constants,
				ResourceIDs: apiResourceDetails.ResourceIDs,
			})

			items = append(items, stages.ModelsStage{
				ServiceName: opts.ServiceName,
				APIVersion:  apiVersion,
				APIResource: apiResourceName,
				Constants:   apiResourceDetails.Constants,
				Models:      apiResourceDetails.Models,
			})

			items = append(items, stages.OperationsStage{
				ServiceName: opts.ServiceName,
				APIVersion:  apiVersion,
				APIResource: apiResourceName,
				Constants:   apiResourceDetails.Constants,
				Models:      apiResourceDetails.Models,
				Operations:  apiResourceDetails.Operations,
			})

			items = append(items, stages.ResourceIDsStage{
				ServiceName: opts.ServiceName,
				APIVersion:  apiVersion,
				APIResource: apiResourceName,
				ResourceIDs: apiResourceDetails.ResourceIDs,
			})
		}
	}

	// Output the Terraform Resource Definitions, if they exist.
	if opts.Service.TerraformDefinition != nil {
		for terraformResourceLabel, terraformResourceDefinition := range opts.Service.TerraformDefinition.Resources {
			items = append(items, stages.TerraformResourceDefinitionStage{
				ServiceName:     opts.ServiceName,
				ResourceLabel:   terraformResourceLabel,
				ResourceDetails: terraformResourceDefinition,
			})

			items = append(items, stages.TerraformSchemaModelsStage{
				ServiceName:     opts.ServiceName,
				ResourceDetails: terraformResourceDefinition,
			})

			items = append(items, stages.TerraformMappingsDefinitionStage{
				ServiceName:     opts.ServiceName,
				ResourceDetails: terraformResourceDefinition,
			})

			items = append(items, stages.TerraformResourceTestsStage{
				ServiceName:     opts.ServiceName,
				ResourceDetails: terraformResourceDefinition,
			})
		}
	}

	fs := helpers.NewFileSystem()

	logging.Log.Debug("Running stages..")
	for _, stage := range items {
		logging.Log.Trace(fmt.Sprintf("Processing Stage %q", stage.Name()))
		if err := stage.Generate(fs); err != nil {
			return fmt.Errorf("running Stage %q: %+v", stage.Name(), err)
		}
	}

	// TODO: ensure that any existing directory for this service is removed

	logging.Log.Debug("Persisting files to disk..")
	if err := helpers.PersistFileSystem(r.workingDirectory, opts.SourceDataType, opts.ServiceName, fs); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
