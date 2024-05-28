// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/stages"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

const commonTypesDirectoryName = "common-types"

type SaveCommonTypesOptions struct {
	// AzureRestAPISpecsGitSHA specifies the Git Commit SHA that these API Definitions were imported from.
	AzureRestAPISpecsGitSHA *string

	// ResourceProvider optionally specifies the Azure Resource Provider associated with this Service.
	// This is only present when SourceDataType is ResourceManagerSourceDataType.
	ResourceProvider *string

	// CommonTypes specifies the CommonTypes to be saved.
	CommonTypes map[string]models.CommonTypes

	// SourceDataOrigin specifies the origin of this set of source data (e.g. AzureRestAPISpecsSourceDataOrigin).
	SourceDataOrigin models.SourceDataOrigin

	// SourceDataType specifies the type of the source data (e.g. ResourceManagerSourceDataType).
	SourceDataType models.SourceDataType
}

// SaveCommonTypes persists the Common Types Definitions for the specified version.
func (r repositoryImpl) SaveCommonTypes(opts SaveCommonTypesOptions) error {
	logging.Log.Info("Processing Common Types")

	items := make([]stages.Stage, 0)

	for apiVersion, commonTypes := range opts.CommonTypes {
		logging.Log.Info(fmt.Sprintf("Processing Common Types for API Version %q..", apiVersion))
		items = append(items, stages.ConstantStage{
			Constants:       commonTypes.Constants,
			OutputDirectory: filepath.Join(commonTypesDirectoryName, apiVersion),
		})

		items = append(items, stages.ModelsStage{
			APIVersion:      apiVersion,
			CommonTypes:     opts.CommonTypes,
			Constants:       commonTypes.Constants,
			Models:          commonTypes.Models,
			OutputDirectory: filepath.Join(commonTypesDirectoryName, apiVersion),
		})
	}

	fs := helpers.NewFileSystem()

	logging.Log.Debug("Running stages..")
	for _, stage := range items {
		logging.Log.Trace(fmt.Sprintf("Processing Stage %q", stage.Name()))
		if err := stage.Generate(fs); err != nil {
			return fmt.Errorf("running Stage %q: %+v", stage.Name(), err)
		}
	}

	logging.Log.Debug("Persisting files to disk..")
	if err := helpers.PersistFileSystem(r.workingDirectory, opts.SourceDataType, commonTypesDirectoryName, nil, fs); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
