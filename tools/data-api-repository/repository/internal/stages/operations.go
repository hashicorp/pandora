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

var _ Stage = OperationsStage{}

type OperationsStage struct {
	// APIResource specifies the APIResource within the APIVersion where the Operations exist.
	APIResource string

	// APIVersion specifies the APIVersion within the Service where the Operations exist.
	APIVersion string

	// CommonTypesForThisAPIVersion specifies the known CommonTypes for this APIVersion.
	CommonTypesForThisAPIVersion sdkModels.CommonTypes

	// Constants specifies the map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	Constants map[string]sdkModels.SDKConstant

	// Models specifies the map of Model Name (key) to SDKModel (value) which should be
	// persisted.
	Models map[string]sdkModels.SDKModel

	// Operations specifies the map of Operation Name (key) to SDKOperation (value) which should be
	// persisted.
	Operations map[string]sdkModels.SDKOperation
}

func (g OperationsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Operations..")
	for operationName := range g.Operations {
		logger.Trace(fmt.Sprintf("Generating Operation %q..", operationName))

		knownData := helpers.KnownData{
			Constants:              g.Constants,
			Models:                 g.Models,
			ResourceIds:            map[string]sdkModels.ResourceID{},
			CommonTypeConstants:    g.CommonTypesForThisAPIVersion.Constants,
			CommonTypeModels:       g.CommonTypesForThisAPIVersion.Models,
			CommonTypesResourceIds: g.CommonTypesForThisAPIVersion.ResourceIDs,
		}

		operationDetails := g.Operations[operationName]
		mapped, err := transforms.MapSDKOperationToRepository(operationName, operationDetails, knownData)
		if err != nil {
			return fmt.Errorf("mapping Operation %q: %+v", operationName, err)
		}

		// {ServiceDirectory}/APIVersion/APIResource/Operation-{Name}.json
		path := filepath.Join(g.APIVersion, g.APIResource, fmt.Sprintf("Operation-%s.json", operationName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Operation %q: %+v", operationName, err)
		}
	}

	return nil
}

func (g OperationsStage) Name() string {
	return "Operations"
}
