package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
)

var _ generatorStage = generateMetaDataStage{}

type generateMetaDataStage struct {
	gitRevision      *string
	sourceDataOrigin models.SourceDataOrigin
	sourceDataType   models.SourceDataType
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
