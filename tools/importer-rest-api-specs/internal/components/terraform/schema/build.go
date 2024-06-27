package schema

import (
	"fmt"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/models"
)

func Build(input models.WorkInProgressData) (*models.WorkInProgressData, error) {
	for resourceLabel := range input.Resources {
		resource := input.Resources[resourceLabel]

		var apiResource sdkModels.APIResource
		builder := NewBuilder(apiResource)
		builder.Build(resource.Resource, resource.InputData)
	}
	return nil, fmt.Errorf("unimplemented")
}
