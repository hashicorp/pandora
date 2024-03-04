// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

var _ generatorStage = generateAPIVersionStage{}

type generateAPIVersionStage struct {
	// serviceName specifies the name of the Service within which this API Version exists.
	serviceName string

	// apiVersion specifies the APIVersion within the current Service.
	apiVersion string

	// isPreviewVersion specifies whether this APIVersion is a Preview (as opposed to a Stable)
	// APIVersion.
	isPreviewVersion bool

	// resources specifies the list of APIResources available within this APIVersion.
	resources map[string]models.APIResource

	// sourceDataOrigin specifies the Origin of this Source Data.
	sourceDataOrigin models.SourceDataOrigin

	// shouldGenerate specifies whether this APIVersion should be marked as available for generation.
	shouldGenerate bool
}

func (g generateAPIVersionStage) generate(input *helpers.FileSystem) error {
	logging.Log.Debug("Generating API Version Definition")
	mapped, err := transforms.MapAPIVersionToRepository(g.apiVersion, g.isPreviewVersion, g.resources, g.sourceDataOrigin, g.shouldGenerate)
	if err != nil {
		return fmt.Errorf("building Api Version Definition: %+v", err)
	}

	path := filepath.Join(g.serviceName, g.apiVersion, "ApiVersionDefinition.json")
	logging.Log.Trace(fmt.Sprintf("Staging API Version Definition to %q", path))
	if err := input.Stage(path, *mapped); err != nil {
		return fmt.Errorf("staging API Version Definition to %q: %+v", path, err)
	}

	return nil
}

func (g generateAPIVersionStage) name() string {
	return "API Version"
}
