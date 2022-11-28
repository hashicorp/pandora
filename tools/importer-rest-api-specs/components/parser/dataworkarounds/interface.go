package dataworkarounds

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type workaround interface {
	IsApplicable(apiDefinition *models.AzureApiDefinition) bool

	Name() string

	Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error)
}
