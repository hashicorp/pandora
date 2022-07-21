package differ

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type ApplyStage interface {
	Apply(existing models.AzureApiDefinition, parsed models.AzureApiDefinition) (*models.AzureApiDefinition, error)
}

var ApplyStages = []ApplyStage{
	// TODO: DefaultImpliedValuesStage{}, - where there's a default implied value in the API
	// TODO: DetectBreakingChangesStage{},
	// TODO: FieldRenamerStage{}, - handling where a field has a different Name and JsonName (casing-aside)
	// TODO: ResourceIdRenamerStage{}, - handling where a ResourceID has been renamed
}
