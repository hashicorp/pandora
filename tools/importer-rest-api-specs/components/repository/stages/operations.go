// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/repository/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/repository/transforms"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

var _ Stage = OperationsStage{}

type OperationsStage struct {
	// APIResource specifies the APIResource within the APIVersion where the Operations exist.
	APIResource string

	// APIVersion specifies the APIVersion within the Service where the Operations exist.
	APIVersion string

	// Constants specifies the map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	Constants map[string]models.SDKConstant

	// Models specifies the map of Model Name (key) to SDKModel (value) which should be
	// persisted.
	Models map[string]models.SDKModel

	// Operations specifies the map of Operation Name (key) to SDKOperation (value) which should be
	// persisted.
	Operations map[string]models.SDKOperation

	// ServiceName specifies the name of the Service within which the Operations exist.
	ServiceName string
}

func (g OperationsStage) Generate(input *helpers.FileSystem) error {
	logging.Log.Debug("Generating Operations..")
	for operationName := range g.Operations {
		logging.Log.Trace(fmt.Sprintf("Generating Operation %q..", operationName))

		operationDetails := g.Operations[operationName]
		mapped, err := transforms.MapSDKOperationToRepository(operationName, operationDetails, g.Constants, g.Models)
		if err != nil {
			return fmt.Errorf("mapping Operation %q: %+v", operationName, err)
		}

		// {workingDirectory}/Service/APIVersion/APIResource/Operation-{Name}.json
		path := filepath.Join(g.ServiceName, g.APIVersion, g.APIResource, fmt.Sprintf("Operation-%s.json", operationName))
		logging.Log.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Operation %q: %+v", operationName, err)
		}
	}

	return nil
}

func (g OperationsStage) Name() string {
	return "Operations"
}
