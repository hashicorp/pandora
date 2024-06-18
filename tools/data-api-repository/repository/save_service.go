// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/stages"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type SaveServiceOptions struct {
	// ResourceProvider optionally specifies the Azure Resource Provider associated with this Service.
	// This is only present when SourceDataType is ResourceManagerSourceDataType.
	ResourceProvider *string

	// Service specifies details about this Service, including the available APIVersions.
	Service sdkModels.Service

	// ServiceName specifies the name of this Service (e.g. `Compute`).
	ServiceName string

	// SourceCommitSHA specifies the Git Commit SHA that these API Definitions were imported from.
	SourceCommitSHA *string

	// SourceDataOrigin specifies the origin of this set of source data (e.g. AzureRestAPISpecsSourceDataOrigin).
	SourceDataOrigin sdkModels.SourceDataOrigin
}

// SaveService persists the API Definitions for the Service specified in opts.
func (r *repositoryImpl) SaveService(opts SaveServiceOptions) error {
	r.logger.Info(fmt.Sprintf("Processing Service %q", opts.ServiceName))

	if opts.ServiceName == helpers.CommonTypesDirectoryName {
		return fmt.Errorf("`ServiceName` cannot be %q since that's reserved for storing Common Types", opts.ServiceName)
	}

	r.cacheLock.Lock()
	defer r.cacheLock.Unlock()

	items := []stages.Stage{
		&stages.MetaDataStage{
			GitRevision:      opts.SourceCommitSHA,
			SourceDataOrigin: opts.SourceDataOrigin,
			SourceDataType:   r.sourceDataType,
		},
		&stages.ServiceDefinitionStage{
			Service: opts.Service,
		},
	}

	for apiVersion, apiVersionDetails := range opts.Service.APIVersions {
		r.logger.Info(fmt.Sprintf("Processing Service %q / API Version %q..", opts.ServiceName, apiVersion))
		items = append(items, stages.APIVersionStage{
			APIVersion:  apiVersionDetails,
			ServiceName: opts.ServiceName,
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

	r.logger.Debug("Running stages..")
	for _, stage := range items {
		r.logger.Trace(fmt.Sprintf("Processing Stage %q", stage.Name()))
		if err := stage.Generate(fs, r.logger); err != nil {
			return fmt.Errorf("running Stage %q: %+v", stage.Name(), err)
		}
	}

	// TODO: ensure that any existing directory for this service is removed

	r.logger.Debug("Persisting files to disk..")
	if err := helpers.PersistFileSystem(r.workingDirectory, r.sourceDataType, opts.ServiceName, fs, r.logger); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
