// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/transforms"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Stage = ModelsStage{}

type ModelsStage struct {
	// APIVersion specifies the APIVersion within the Service where the Models exist.
	APIVersion string

	// APIResource specifies the APIResource within the APIVersion where the Models exist.
	APIResource string

	// CommonTypesForThisAPIVersion specifies the known CommonTypes for this APIVersion.
	CommonTypesForThisAPIVersion sdkModels.CommonTypes

	// Constants specifies the map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	Constants map[string]sdkModels.SDKConstant

	// Models specifies the map of Model Name (key) to SDKModel (value) which should be
	// persisted.
	Models map[string]sdkModels.SDKModel
}

func (g ModelsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Models")
	for modelName := range g.Models {
		logger.Trace(fmt.Sprintf("Generating Model %q..", modelName))
		modelValue := g.Models[modelName]

		var parent *sdkModels.SDKModel
		if modelValue.ParentTypeName != nil {
			logger.Trace("Finding parent model %q..", *modelValue.ParentTypeName)
			p, ok := g.Models[*modelValue.ParentTypeName]
			if ok {
				parent = &p
			}
		}

		knownData := helpers.KnownData{
			Constants:           g.Constants,
			Models:              g.Models,
			ResourceIds:         map[string]sdkModels.ResourceID{},
			CommonTypeConstants: g.CommonTypesForThisAPIVersion.Constants,
			CommonTypeModels:    g.CommonTypesForThisAPIVersion.Models,
		}

		mapped, err := transforms.MapSDKModelToRepository(modelName, modelValue, parent, knownData)
		if err != nil {
			return fmt.Errorf("mapping model %q: %+v", modelName, err)
		}

		// {ServiceDirectory}/APIVersion/APIResource/Model-{Name}.json
		path := filepath.Join(g.APIVersion, g.APIResource, fmt.Sprintf("Model-%s.json", modelName))
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
