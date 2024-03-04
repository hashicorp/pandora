// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

var _ generatorStage = generateResourceIDsStage{}

type generateResourceIDsStage struct {
	// serviceName specifies the name of the Service within which the Resource IDs exist.
	serviceName string

	// apiVersion specifies the APIVersion within the Service where the Resource IDs exist.
	apiVersion string

	// apiResource specifies the APIResource within the APIVersion where the Resource IDs exist.
	apiResource string

	// resourceIDs specifies a map of Resource ID Name (key) to ResourceID (value) that should
	// be persisted.
	resourceIDs map[string]models.ResourceID
}

func (g generateResourceIDsStage) generate(input *fileSystem) error {
	logging.Log.Debug("Generating Resource IDs")
	for resourceIDName, resourceIDValue := range g.resourceIDs {
		logging.Log.Trace(fmt.Sprintf("Generating Resource ID %q", resourceIDName))
		mapped, err := transforms.MapResourceIDToRepository(resourceIDName, resourceIDValue)
		if err != nil {
			return fmt.Errorf("mapping Resource ID %q: %+v", resourceIDName, err)
		}

		// {workingDirectory}/Service/APIVersion/APIResource/ResourceId-{Name}.json
		path := filepath.Join(g.serviceName, g.apiVersion, g.apiResource, fmt.Sprintf("ResourceId-%s.json", resourceIDName))
		logging.Log.Trace(fmt.Sprintf("Staging to %s", path))
		if err := input.stage(path, *mapped); err != nil {
			return fmt.Errorf("staging Resource ID %q: %+v", resourceIDName, err)
		}
	}

	return nil
}

func (g generateResourceIDsStage) name() string {
	return "Resource IDs"
}
