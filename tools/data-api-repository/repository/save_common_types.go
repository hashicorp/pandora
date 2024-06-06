// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/stages"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type SaveCommonTypesOptions struct {
	// ResourceProvider optionally specifies the Azure Resource Provider associated with this Service.
	// This is only present when SourceDataType is ResourceManagerSourceDataType.
	ResourceProvider *string

	// CommonTypes specifies a map of API Version (key) to CommonTypes (value) to be saved.
	CommonTypes map[string]models.CommonTypes

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
		items = append(items, stages.CommonTypesConstantStage{
			APIVersion: apiVersion,
			Constants:  commonTypes.Constants,
		})

		items = append(items, stages.CommonTypesModelsStage{
			APIVersion:  apiVersion,
			CommonTypes: opts.CommonTypes,
			Constants:   commonTypes.Constants,
			Models:      commonTypes.Models,
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
	if err := helpers.PersistFileSystem(r.workingDirectory, opts.SourceDataType, fs, r.logger); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
