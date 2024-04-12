// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/transforms"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Stage = ResourceIDsStage{}

type ResourceIDsStage struct {
	// APIVersion specifies the APIVersion within the Service where the Resource IDs exist.
	APIVersion string

	// APIResource specifies the APIResource within the APIVersion where the Resource IDs exist.
	APIResource string

	// ResourceIDs specifies a map of Resource ID Name (key) to ResourceID (value) that should
	// be persisted.
	ResourceIDs map[string]models.ResourceID

	// ServiceName specifies the name of the Service within which the Resource IDs exist.
	ServiceName string
}

func (g ResourceIDsStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	logger.Debug("Generating Resource IDs")
	for resourceIDName, resourceIDValue := range g.ResourceIDs {
		logger.Trace(fmt.Sprintf("Generating Resource ID %q", resourceIDName))
		mapped, err := transforms.MapResourceIDToRepository(resourceIDName, resourceIDValue)
		if err != nil {
			return fmt.Errorf("mapping Resource ID %q: %+v", resourceIDName, err)
		}

		// {workingDirectory}/Service/APIVersion/APIResource/ResourceId-{Name}.json
		path := filepath.Join(g.ServiceName, g.APIVersion, g.APIResource, fmt.Sprintf("ResourceId-%s.json", resourceIDName))
		logger.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.Stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Resource ID %q: %+v", resourceIDName, err)
		}
	}

	return nil
}

func (g ResourceIDsStage) Name() string {
	return "Resource IDs"
}
