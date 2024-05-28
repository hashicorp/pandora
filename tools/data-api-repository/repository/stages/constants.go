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

var _ Stage = ConstantStage{}

type ConstantStage struct {
	// Constants specifies the map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	Constants map[string]models.SDKConstant

	// OutputDirectory specifies the path where constants should be persisted.
	OutputDirectory string

	// ResourceIDs specifies a map of Resource ID Name (key) to ResourceID (value) that should
	// be persisted.
	ResourceIDs map[string]models.ResourceID
}

func (g ConstantStage) Name() string {
	return "Constants"
}

func (g ConstantStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Constants")

	if g.OutputDirectory == "" {
		return fmt.Errorf("internal: OutputDirectory cannot be empty")
	}

	for constantName, constantVal := range g.Constants {
		logger.Trace(fmt.Sprintf("Processing Constant %q", constantName))

		mapped, err := transforms.MapSDKConstantToRepository(constantName, constantVal)
		if err != nil {
			return fmt.Errorf("mapping SDKConstant %q: %+v", constantName, err)
		}

		path := filepath.Join(g.OutputDirectory, fmt.Sprintf("Constant-%s.json", constantName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Constant %q: %+v", constantName, err)
		}
	}

	// ResourceIDs also contain Constants - so we need to pull those out and persist them too
	for resourceIdName, resourceId := range g.ResourceIDs {
		logger.Trace(fmt.Sprintf("Processing Constants within the Resource ID %q", resourceIdName))

		for constantName, constantVal := range resourceId.Constants {
			logger.Trace(fmt.Sprintf("Processing Constant %q", constantName))

			mapped, err := transforms.MapSDKConstantToRepository(constantName, constantVal)
			if err != nil {
				return fmt.Errorf("mapping SDKConstant %q: %+v", constantName, err)
			}

			path := filepath.Join(g.OutputDirectory, fmt.Sprintf("Constant-%s.json", constantName))
			logger.Trace(fmt.Sprintf("Staging to %s", path))
			if err := input.Stage(path, *mapped); err != nil {
				return fmt.Errorf("staging Constant %q: %+v", constantName, err)
			}
		}
	}

	return nil
}
