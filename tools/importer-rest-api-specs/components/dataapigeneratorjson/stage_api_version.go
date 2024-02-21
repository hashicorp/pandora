// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ generatorStage = generateAPIVersionStage{}

type generateAPIVersionStage struct {
	serviceName      string
	apiVersion       string
	isPreviewVersion bool
	resources        map[string]importerModels.AzureApiResource
	sourceDataOrigin models.SourceDataOrigin
	shouldGenerate   bool
}

func (g generateAPIVersionStage) generate(input *fileSystem, logger hclog.Logger) error {
	logger.Debug("Generating API Version Definition")
	mapped, err := transforms.MapAPIVersionToRepository(g.apiVersion, g.isPreviewVersion, g.resources, g.sourceDataOrigin, g.shouldGenerate)
	if err != nil {
		return fmt.Errorf("building Api Version Definition: %+v", err)
	}

	path := filepath.Join(g.serviceName, g.apiVersion, "ApiVersionDefinition.json")
	logger.Trace(fmt.Sprintf("Staging API Version Definition to %q", path))
	if err := input.stage(path, *mapped); err != nil {
		return fmt.Errorf("staging API Version Definition to %q: %+v", path, err)
	}

	return nil
}

func (g generateAPIVersionStage) name() string {
	return "API Version"
}
