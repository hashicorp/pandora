// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var _ Stage = APIVersionStage{}

type APIVersionStage struct {
	// APIResources specifies a mapping of APIResources available within this APIVersion.
	APIResources map[string]models.APIResource

	// APIVersion specifies the APIVersion within the current Service.
	APIVersion string

	// IsPreviewVersion specifies whether this APIVersion is a Preview (as opposed to a Stable)
	// APIVersion.
	IsPreviewVersion bool

	// ServiceName specifies the name of the Service within which this API Version exists.
	ServiceName string

	// SourceDataOrigin specifies the Origin of this Source Data.
	SourceDataOrigin models.SourceDataOrigin

	// ShouldGenerate specifies whether this APIVersion should be marked as available for generation.
	ShouldGenerate bool
}

func (g APIVersionStage) Generate(input *helpers.FileSystem) error {
	logging.Log.Debug("Generating API Version Definition")
	mapped, err := transforms.MapAPIVersionToRepository(g.APIVersion, g.IsPreviewVersion, g.APIResources, g.SourceDataOrigin, g.ShouldGenerate)
	if err != nil {
		return fmt.Errorf("building Api Version Definition: %+v", err)
	}

	path := filepath.Join(g.ServiceName, g.APIVersion, "ApiVersionDefinition.json")
	logging.Log.Trace(fmt.Sprintf("Staging API Version Definition to %q", path))
	if err := input.Stage(path, *mapped); err != nil {
		return fmt.Errorf("staging API Version Definition to %q: %+v", path, err)
	}

	return nil
}

func (g APIVersionStage) Name() string {
	return "API Version"
}
