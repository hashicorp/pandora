// Copyright IBM Corp. 2021, 2025
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

var _ Stage = CommonTypesConstantStage{}

type CommonTypesConstantStage struct {
	// APIVersion specifies the APIVersion within the Service where the Constants exist.
	APIVersion string

	// CommonTypeConstants specifies a map of Constant Name (key) to SDKConstant (value) which should be
	// persisted.
	CommonTypeConstants map[string]sdkModels.SDKConstant
}

func (g CommonTypesConstantStage) Name() string {
	return "Common Types Constants"
}

func (g CommonTypesConstantStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Common Types Constants")

	for constantName, constantVal := range g.CommonTypeConstants {
		logger.Trace(fmt.Sprintf("Processing Common Types Constant %q", constantName))

		mapped, err := transforms.MapSDKConstantToRepository(constantName, constantVal)
		if err != nil {
			return fmt.Errorf("mapping SDKConstant %q: %+v", constantName, err)
		}

		// {workingDirectory}/common-types/{APIVersion}/Constant-{Name}.json
		path := filepath.Join(helpers.CommonTypesDirectoryName, g.APIVersion, fmt.Sprintf("Constant-%s.json", constantName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Common Types Constant %q: %+v", constantName, err)
		}
	}

	return nil
}
