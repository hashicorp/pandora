// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/repository/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/repository/transforms"
)

var _ Stage = ModelsStage{}

type ModelsStage struct {
	// APIVersion specifies the APIVersion within the Service where the Models exist.
	APIVersion string

	// APIResource specifies the APIResource within the APIVersion where the Models exist.
	APIResource string

	// Constants specifies the map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	Constants map[string]models.SDKConstant

	// Models specifies the map of Model Name (key) to SDKModel (value) which should be
	// persisted.
	Models map[string]models.SDKModel

	// ServiceName specifies the name of the Service within which the Models exist.
	ServiceName string
}

func (g ModelsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Models")
	for modelName := range g.Models {
		logger.Trace(fmt.Sprintf("Generating Model %q..", modelName))
		modelValue := g.Models[modelName]

		var parent *models.SDKModel
		if modelValue.ParentTypeName != nil {
			logger.Trace("Finding parent model %q..", *modelValue.ParentTypeName)
			p, ok := g.Models[*modelValue.ParentTypeName]
			if ok {
				parent = &p
			}
		}

		mapped, err := transforms.MapSDKModelToRepository(modelName, modelValue, parent, g.Constants, g.Models)
		if err != nil {
			return fmt.Errorf("mapping model %q: %+v", modelName, err)
		}

		// {workingDirectory}/Service/APIVersion/APIResource/Model-{Name}.json
		path := filepath.Join(g.ServiceName, g.APIVersion, g.APIResource, fmt.Sprintf("Model-%s.json", modelName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Model %q: %+v", modelName, err)
		}
	}

	return nil
}

func (g ModelsStage) Name() string {
	return "Models"
}
