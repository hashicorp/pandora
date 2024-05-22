// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/helpers"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var _ Stage = MetaDataStage{}

type MetaDataStage struct {
	// GitRevision optionally specifies the Git Revision (the full SHA) that the API Definitions have been
	// parsed from. This can be nil when the APIDefinitions are handwritten.
	GitRevision *string

	// SourceDataOrigin specifies the Origin of this Source Data.
	SourceDataOrigin models.SourceDataOrigin

	// SourceDataType specifies the Type of Source Data that this set of API Definitions is related to.
	SourceDataType models.SourceDataType
}

func (g MetaDataStage) Generate(input *helpers.FileSystem) error {
	metaData, err := transforms.MapMetaDataToRepository(g.GitRevision, g.SourceDataType, g.SourceDataOrigin)
	if err != nil {
		return fmt.Errorf("mapping metadata: %+v", err)
	}
	path := "metadata.json"

	logging.Log.Trace(fmt.Sprintf("Staging MetaData at %s", path))
	if err := input.Stage(path, *metaData); err != nil {
		return fmt.Errorf("staging metadata: %+v", err)
	}

	return nil
}

func (g MetaDataStage) Name() string {
	return "MetaData"
}
