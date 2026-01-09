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

var _ Stage = CommonTypesResourceIDsStage{}

type CommonTypesResourceIDsStage struct {
	// APIVersion specifies the APIVersion within the Service where the Resource IDs exist.
	APIVersion string

	// CommonTypesResourceIDs specifies a map of Resource ID Name (key) to ResourceID (value) that should
	// be persisted.
	CommonTypesResourceIDs map[string]sdkModels.ResourceID
}

func (g CommonTypesResourceIDsStage) Name() string {
	return "Common Types Resource IDs"
}

func (g CommonTypesResourceIDsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Common Types Resource IDs")
	for resourceIDName, resourceIDValue := range g.CommonTypesResourceIDs {
		logger.Trace(fmt.Sprintf("Generating Resource ID %q", resourceIDName))
		mapped, err := transforms.MapResourceIDToRepository(resourceIDName, resourceIDValue)
		if err != nil {
			return fmt.Errorf("mapping Resource ID %q: %+v", resourceIDName, err)
		}

		// {workingDirectory}/common-types/{APIVersion}/ResourceId-{Name}.json
		path := filepath.Join(helpers.CommonTypesDirectoryName, g.APIVersion, fmt.Sprintf("ResourceId-%s.json", resourceIDName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err = input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Resource ID %q: %+v", resourceIDName, err)
		}
	}

	return nil
}
