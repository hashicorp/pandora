// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
)

var _ generatorStage = generateMetaDataStage{}

type generateMetaDataStage struct {
	// gitRevision optionally specifies the Git Revision (the full SHA) that the API Definitions have been
	// parsed from. This can be nil when the APIDefinitions are handwritten.
	gitRevision *string

	// sourceDataOrigin specifies the Origin of this Source Data.
	sourceDataOrigin models.SourceDataOrigin

	// sourceDataType specifies the Type of Source Data that this set of API Definitions is related to.
	sourceDataType models.SourceDataType
}

func (g generateMetaDataStage) generate(input *fileSystem, logger hclog.Logger) error {
	metaData, err := transforms.MapMetaDataToRepository(g.gitRevision, g.sourceDataType, g.sourceDataOrigin)
	if err != nil {
		return fmt.Errorf("mapping metadata: %+v", err)
	}
	path := "metadata.json"

	logger.Trace(fmt.Sprintf("Staging MetaData at %s", path))
	if err := input.stage(path, *metaData); err != nil {
		return fmt.Errorf("staging metadata: %+v", err)
	}

	return nil
}

func (g generateMetaDataStage) name() string {
	return "MetaData"
}
