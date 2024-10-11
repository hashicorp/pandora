// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/stages"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type SaveCommonTypesOptions struct {
	// CommonTypes specifies a map of APIVersion (Key) to CommonTypes (Value)
	CommonTypes map[string]sdkModels.CommonTypes

	// SourceDataOrigin specifies the SourceDataOrigin
	SourceDataOrigin sdkModels.SourceDataOrigin
}

// SaveCommonTypes persists the Common Types for the current SourceDataType/SourceDataOrigin combination.
func (r *repositoryImpl) SaveCommonTypes(opts SaveCommonTypesOptions) error {
	r.logger.Info("Processing Common Types")

	items := make([]stages.Stage, 0)

	for apiVersion, commonTypes := range opts.CommonTypes {
		r.logger.Info(fmt.Sprintf("Processing Common Types for API Version %q..", apiVersion))
		items = append(items, stages.CommonTypesConstantStage{
			APIVersion:          apiVersion,
			CommonTypeConstants: commonTypes.Constants,
		})

		items = append(items, stages.CommonTypesModelsStage{
			APIVersion:          apiVersion,
			CommonTypeConstants: commonTypes.Constants,
			CommonTypeModels:    commonTypes.Models,
		})

		items = append(items, stages.CommonTypesResourceIDsStage{
			APIVersion:             apiVersion,
			CommonTypesResourceIDs: commonTypes.ResourceIDs,
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

	dataDirectory, err := r.defaultDirectoryForSourceDataOrigin(opts.SourceDataOrigin)
	if err != nil {
		return fmt.Errorf("determining the default data directory for the Source Data Origin %q: %+v", opts.SourceDataOrigin, err)
	}

	r.logger.Debug("Persisting files to disk..")
	if err := helpers.PersistFileSystem(*dataDirectory, fs, r.logger); err != nil {
		return fmt.Errorf("persisting files: %+v", err)
	}

	return nil
}
