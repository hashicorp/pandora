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

var _ Stage = APIVersionStage{}

type APIVersionStage struct {
	// APIVersion specifies the APIVersion for the current Service.
	APIVersion sdkModels.APIVersion
}

func (g APIVersionStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating API Version Definition")
	mapped, err := transforms.MapAPIVersionToRepository(g.APIVersion)
	if err != nil {
		return fmt.Errorf("building Api Version Definition: %+v", err)
	}

	path := filepath.Join(g.APIVersion.APIVersion, "ApiVersionDefinition.json")
	logger.Trace(fmt.Sprintf("Staging API Version Definition to %q", path))
	if err := input.Stage(path, *mapped); err != nil {
		return fmt.Errorf("staging API Version Definition to %q: %+v", path, err)
	}

	return nil
}

func (g APIVersionStage) Name() string {
	return "API Version"
}
