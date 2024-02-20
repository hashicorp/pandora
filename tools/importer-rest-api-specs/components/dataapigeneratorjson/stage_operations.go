// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ generatorStage = generateOperationsStage{}

type generateOperationsStage struct {
	// serviceName specifies the name of the Service within which the Operations exist.
	serviceName string

	// apiVersion specifies the APIVersion within the Service where the Operations exist.
	apiVersion string

	// apiResource specifies the APIResource within the APIVersion where the Operations exist.
	apiResource string

	// constants specifies the map of Constant Name (key) to ConstantDetails (value) which should be
	// persisted.
	constants map[string]resourcemanager.ConstantDetails

	// models specifies the map of Model Name (key) to ModelDetails (value) which should be
	// persisted.
	models map[string]resourcemanager.ModelDetails

	// operations specifies the map of Operation Name (key) to ApiOperation (value) which should be
	// persisted.
	operations map[string]resourcemanager.ApiOperation
}

func (g generateOperationsStage) generate(input *fileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Operations..")
	for operationName, operationDetails := range g.operations {
		logger.Trace(fmt.Sprintf("Generating Operation %q..", operationName))
		mapped, err := transforms.MapSDKOperationToRepository(operationName, operationDetails, g.constants, g.models)
		if err != nil {
			return fmt.Errorf("mapping Operation %q: %+v", operationName, err)
		}

		// {workingDirectory}/Service/APIVersion/APIResource/Operation-{Name}.json
		path := filepath.Join(g.serviceName, g.apiVersion, g.apiResource, fmt.Sprintf("Operation-%s.json", operationName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Operation %q: %+v", operationName, err)
		}
	}

	return nil
}

func (g generateOperationsStage) name() string {
	return "Operations"
}
