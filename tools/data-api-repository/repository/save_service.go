// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/stages"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type SaveServiceOptions struct {
	// CommonTypes specifies a map of API Version (key) to CommonTypes (value)
	// which defines the available Common Types for this Service.
	CommonTypes map[string]models.CommonTypes

	// ResourceProvider optionally specifies the Azure Resource Provider associated with this Service.
	// This is only present when SourceDataType is ResourceManagerSourceDataType.
	ResourceProvider *string

	// Service specifies details about this Service, including the available APIVersions.
	Service models.Service

	// ServiceName specifies the name of this Service (e.g. `Compute`).
	ServiceName string

	// SourceCommitSHA specifies the Git Commit SHA that these API Definitions were imported from.
	SourceCommitSHA *string

	// SourceDataOrigin specifies the origin of this set of source data (e.g. AzureRestAPISpecsSourceDataOrigin).
	SourceDataOrigin models.SourceDataOrigin

	// SourceDataType specifies the type of the source data (e.g. ResourceManagerSourceDataType).
	SourceDataType models.SourceDataType
}

// SaveService persists the API Definitions for the Service specified in opts.
func (r repositoryImpl) SaveService(opts SaveServiceOptions) error {
	r.logger.Info(fmt.Sprintf("Processing Service %q", opts.ServiceName))

	items := []stages.Stage{
		stages.MetaDataStage{
			GitRevision:      opts.SourceCommitSHA,
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
		r.logger.Info(fmt.Sprintf("Processing Service %q / API Version %q..", opts.ServiceName, apiVersion))
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
				Constants:       apiResourceDetails.Constants,
				OutputDirectory: filepath.Join(opts.ServiceName, apiVersion, apiResourceName),
				ResourceIDs:     apiResourceDetails.ResourceIDs,
			})

			items = append(items, stages.ModelsStage{
				APIVersion:      apiVersion,
				CommonTypes:     opts.CommonTypes,
				Constants:       apiResourceDetails.Constants,
				Models:          apiResourceDetails.Models,
				OutputDirectory: filepath.Join(opts.ServiceName, apiVersion, apiResourceName),
			})

			items = append(items, stages.OperationsStage{
				ServiceName: opts.ServiceName,
				APIVersion:  apiVersion,
				APIResource: apiResourceName,
				CommonTypes: opts.CommonTypes,
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

	r.logger.Debug("Running stages..")
	for _, stage := range items {
		r.logger.Trace(fmt.Sprintf("Processing Stage %q", stage.Name()))
		if err := stage.Generate(fs, r.logger); err != nil {
			return fmt.Errorf("running Stage %q: %+v", stage.Name(), err)
		}
	}

	// TODO: ensure that any existing directory for this service is removed

	r.logger.Debug("Persisting files to disk..")
	if err := helpers.PersistFileSystem(r.workingDirectory, opts.SourceDataType, opts.ServiceName, &opts.ServiceName, fs, r.logger); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
