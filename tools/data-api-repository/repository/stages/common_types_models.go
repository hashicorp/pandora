// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/transforms"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Stage = CommonTypesModelsStage{}

type CommonTypesModelsStage struct {
	// APIVersion specifies the APIVersion within the Service where the Models exist.
	APIVersion string

	// CommonTypes specifies a map of API Version (key) to CommonTypes (value)
	// which defines the known Common Types.
	CommonTypes map[string]models.CommonTypes

	// Constants specifies the map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	Constants map[string]models.SDKConstant

	// Models specifies the map of Model Name (key) to SDKModel (value) which should be
	// persisted.
	Models map[string]models.SDKModel
}

func (g CommonTypesModelsStage) Name() string {
	return "Common Types Models"
}

func (g CommonTypesModelsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Common Types Models")
	for modelName := range g.Models {
		logger.Trace(fmt.Sprintf("Generating Common Types Model %q..", modelName))
		modelValue := g.Models[modelName]

		var parent *models.SDKModel
		if modelValue.ParentTypeName != nil {
			logger.Trace("Finding parent model %q..", *modelValue.ParentTypeName)
			p, ok := g.Models[*modelValue.ParentTypeName]
			if ok {
				parent = &p
			}
		}

		var commonTypes models.CommonTypes
		if commonTypesForVersion, ok := g.CommonTypes[g.APIVersion]; ok {
			commonTypes = commonTypesForVersion
		}

		mapped, err := transforms.MapSDKModelToRepository(modelName, modelValue, parent, g.Constants, g.Models, commonTypes)
		if err != nil {
			return fmt.Errorf("mapping model %q: %+v", modelName, err)
		}

		// {workingDirectory}/common-types/APIVersion/Model-{Name}.json
		path := filepath.Join(commonTypesDirectoryName, g.APIVersion, fmt.Sprintf("Model-%s.json", modelName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err = input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Common Types Model %q: %+v", modelName, err)
		}
	}

	return nil
}
