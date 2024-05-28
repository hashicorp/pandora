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

const commonTypesDirectoryName = "common-types"

type SaveCommonTypesOptions struct {
	// ResourceProvider optionally specifies the Azure Resource Provider associated with this Service.
	// This is only present when SourceDataType is ResourceManagerSourceDataType.
	ResourceProvider *string

	// CommonTypes specifies the CommonTypes to be saved.
	CommonTypes map[string]models.CommonTypes

	// SourceCommitSHA specifies the Git Commit SHA that these API Definitions were imported from.
	SourceCommitSHA *string

	// SourceDataOrigin specifies the origin of this set of source data (e.g. AzureRestAPISpecsSourceDataOrigin).
	SourceDataOrigin models.SourceDataOrigin

	// SourceDataType specifies the type of the source data (e.g. ResourceManagerSourceDataType).
	SourceDataType models.SourceDataType
}

// SaveCommonTypes persists the Common Types Definitions for the specified version.
func (r repositoryImpl) SaveCommonTypes(opts SaveCommonTypesOptions) error {
	r.logger.Info("Processing Common Types")

	items := make([]stages.Stage, 0)

	for apiVersion, commonTypes := range opts.CommonTypes {
		r.logger.Info(fmt.Sprintf("Processing Common Types for API Version %q..", apiVersion))
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

	r.logger.Debug("Running stages..")
	for _, stage := range items {
		r.logger.Trace(fmt.Sprintf("Processing Stage %q", stage.Name()))
		if err := stage.Generate(fs, r.logger); err != nil {
			return fmt.Errorf("running Stage %q: %+v", stage.Name(), err)
		}
	}

	r.logger.Debug("Persisting files to disk..")
	if err := helpers.PersistFileSystem(r.workingDirectory, opts.SourceDataType, commonTypesDirectoryName, nil, fs, r.logger); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
