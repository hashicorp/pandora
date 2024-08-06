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

	// CommonTypes specifies a map of API Version (key) to CommonTypes (value), which defines the known Common Types.
	CommonTypes map[string]sdkModels.CommonTypes

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
		&stages.ServiceDefinitionStage{
			Service: opts.Service,
		},
	}

	for apiVersion, apiVersionDetails := range opts.Service.APIVersions {
		r.logger.Info(fmt.Sprintf("Processing Service %q / API Version %q..", opts.ServiceName, apiVersion))
		items = append(items, stages.APIVersionStage{
			APIVersion: apiVersionDetails,
		})

		commonTypesForThisApiVersion := sdkModels.CommonTypes{}
		if opts.CommonTypes != nil {
			commonTypesForThisApiVersion, _ = opts.CommonTypes[apiVersion]
		}

		for apiResourceName, apiResourceDetails := range apiVersionDetails.Resources {
			// Output the API Definitions for this APIResource

			items = append(items, stages.ConstantStage{
				APIVersion:  apiVersion,
				APIResource: apiResourceName,
				Constants:   apiResourceDetails.Constants,
				ResourceIDs: apiResourceDetails.ResourceIDs,
			})

			items = append(items, stages.ModelsStage{
				APIVersion:                   apiVersion,
				APIResource:                  apiResourceName,
				CommonTypesForThisAPIVersion: commonTypesForThisApiVersion,
				Constants:                    apiResourceDetails.Constants,
				Models:                       apiResourceDetails.Models,
			})

			items = append(items, stages.OperationsStage{
				APIVersion:                   apiVersion,
				APIResource:                  apiResourceName,
				CommonTypesForThisAPIVersion: commonTypesForThisApiVersion,
				Constants:                    apiResourceDetails.Constants,
				Models:                       apiResourceDetails.Models,
				Operations:                   apiResourceDetails.Operations,
			})

			items = append(items, stages.ResourceIDsStage{
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
				ResourceLabel:   terraformResourceLabel,
				ResourceDetails: terraformResourceDefinition,
			})

			items = append(items, stages.TerraformSchemaModelsStage{
				ResourceDetails: terraformResourceDefinition,
			})

			items = append(items, stages.TerraformMappingsDefinitionStage{
				ResourceDetails: terraformResourceDefinition,
			})

			items = append(items, stages.TerraformResourceTestsStage{
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

	serviceDirectory, err := r.directoryForService(opts.ServiceName, opts.SourceDataOrigin)
	if err != nil {
		return fmt.Errorf("determining the directory for Service %q: %+v", opts.ServiceName, err)
	}

	r.logger.Debug(fmt.Sprintf("Persisting the Service API Definitions into %q..", *serviceDirectory))
	if err := helpers.PersistFileSystem(*serviceDirectory, fs, r.logger); err != nil {
		return fmt.Errorf("persisting Service API Definitions into %q: %+v", *serviceDirectory, err)
	}

	// then populate the source data information into the metadata file
	if err := r.writeSourceDataInformation(opts.SourceDataOrigin, opts.SourceCommitSHA); err != nil {
		return fmt.Errorf("populating the Source Data Information into %q: %+v", *serviceDirectory, err)
	}

	return nil
}
