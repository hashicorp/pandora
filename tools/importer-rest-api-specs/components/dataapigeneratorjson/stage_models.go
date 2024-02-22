// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
)

var _ generatorStage = generateModelsStage{}

type generateModelsStage struct {
	// serviceName specifies the name of the Service within which the Models exist.
	serviceName string

	// apiVersion specifies the APIVersion within the Service where the Models exist.
	apiVersion string

	// apiResource specifies the APIResource within the APIVersion where the Models exist.
	apiResource string

	// constants specifies the map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	constants map[string]models.SDKConstant

	// models specifies the map of Model Name (key) to SDKModel (value) which should be
	// persisted.
	models map[string]models.SDKModel
}

func (g generateModelsStage) generate(input *fileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Models")
	for modelName, modelValue := range g.models {
		logger.Trace(fmt.Sprintf("Generating Model %q..", modelName))
		var parent *models.SDKModel
		if modelValue.ParentTypeName != nil {
			logger.Trace("Finding parent model %q..", *modelValue.ParentTypeName)
			p, ok := g.models[*modelValue.ParentTypeName]
			if ok {
				parent = &p
			}
		}

		mapped, err := transforms.MapSDKModelToRepository(modelName, modelValue, parent, g.constants, g.models)
		if err != nil {
			return fmt.Errorf("mapping model %q: %+v", modelName, err)
		}

		// {workingDirectory}/Service/APIVersion/APIResource/Model-{Name}.json
		path := filepath.Join(g.serviceName, g.apiVersion, g.apiResource, fmt.Sprintf("Model-%s.json", modelName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Model %q: %+v", modelName, err)
		}
	}

	return nil
}

func (g generateModelsStage) name() string {
	return "Models"
}
