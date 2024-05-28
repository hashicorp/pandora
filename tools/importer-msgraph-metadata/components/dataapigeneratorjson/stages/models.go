// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var _ Stage = ModelsStage{}

type ModelsStage struct {
	// APIVersion specifies the APIVersion within the Service where the Models exist.
	APIVersion string

	// CommonTypes specifies a map of API Version (key) to CommonTypes (value)
	// which defines the available Common Types for this Service.
	CommonTypes map[string]models.CommonTypes

	// Constants specifies the map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	Constants map[string]models.SDKConstant

	// Models specifies the map of Model Name (key) to SDKModel (value) which should be
	// persisted.
	Models map[string]models.SDKModel

	// OutputDirectory specifies the path where constants should be persisted.
	OutputDirectory string
}

func (g ModelsStage) Generate(input *helpers.FileSystem) error {
	logging.Log.Debug("Generating Models")

	if g.OutputDirectory == "" {
		return fmt.Errorf("internal: OutputDirectory cannot be empty")
	}

	for modelName := range g.Models {
		logging.Log.Trace(fmt.Sprintf("Generating Model %q..", modelName))
		modelValue := g.Models[modelName]

		var parent *models.SDKModel
		if modelValue.ParentTypeName != nil {
			logging.Log.Trace("Finding parent model %q..", *modelValue.ParentTypeName)
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

		path := filepath.Join(g.OutputDirectory, fmt.Sprintf("Model-%s.json", modelName))
		logging.Log.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Model %q: %+v", modelName, err)
		}
	}

	return nil
}

func (g ModelsStage) Name() string {
	return "Models"
}
