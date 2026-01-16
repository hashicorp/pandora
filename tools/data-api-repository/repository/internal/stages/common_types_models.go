// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/transforms"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Stage = CommonTypesModelsStage{}

type CommonTypesModelsStage struct {
	// APIVersion specifies the APIVersion within the Service where the Models exist.
	APIVersion string

	// CommonTypeConstants specifies a map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	CommonTypeConstants map[string]models.SDKConstant

	// CommonTypeModels specifies a map of Model Name (key) to SDKModel (value) which should be
	// persisted.
	CommonTypeModels map[string]models.SDKModel
}

func (g CommonTypesModelsStage) Name() string {
	return "Common Types Models"
}

func (g CommonTypesModelsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Common Types Models")
	knownData := helpers.KnownData{
		Constants:           make(map[string]models.SDKConstant),
		Models:              make(map[string]models.SDKModel),
		ResourceIds:         make(map[string]models.ResourceID),
		CommonTypeConstants: g.CommonTypeConstants,
		CommonTypeModels:    g.CommonTypeModels,
	}

	for modelName := range g.CommonTypeModels {
		logger.Trace(fmt.Sprintf("Generating Common Types Model %q..", modelName))
		model := knownData.ModelByName(modelName)
		if model == nil {
			return fmt.Errorf("internal-error: unable to find the Common Types Model %q", modelName)
		}

		var parent *models.SDKModel
		if model.ParentTypeName != nil {
			logger.Trace("Finding parent Common Types Model %q..", *model.ParentTypeName)
			parent = knownData.ModelByName(*model.ParentTypeName)
		}

		mapped, err := transforms.MapSDKModelToRepository(modelName, *model, parent, knownData)
		if err != nil {
			return fmt.Errorf("mapping model %q: %+v", modelName, err)
		}

		// {workingDirectory}/common-types/{APIVersion}/Model-{Name}.json
		path := filepath.Join(helpers.CommonTypesDirectoryName, g.APIVersion, fmt.Sprintf("Model-%s.json", modelName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err = input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Common Types Model %q: %+v", modelName, err)
		}
	}

	return nil
}
