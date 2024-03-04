package pipeline

import "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

type Pipeline struct {
}

type Options struct {
	sourceDataType   models.SourceDataType
	sourceDataOrigin models.SourceDataOrigin
}
