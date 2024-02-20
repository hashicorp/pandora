package transforms

import (
	"fmt"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapSDKFieldToRepository(fieldName string, fieldDetails importerModels.FieldDetails, isTypeHint bool, constants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails) (*dataapimodels.ModelField, error) {
	// TODO: thread through logging
	objectDefinition, err := MapSDKObjectDefinitionToRepository(fieldDetails, constants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping the ObjectDefinition for field %q: %+v", fieldName, err)
	}

	return &dataapimodels.ModelField{
		ContainsDiscriminatedTypeValue: isTypeHint,
		JsonName:                       fieldDetails.JsonName,
		Name:                           fieldName,
		ObjectDefinition:               *objectDefinition,
		// TODO: support Optional being a distinct value in-time so we can have ReadOnly fields too
		Optional: !fieldDetails.Required,
		Required: fieldDetails.Required,
		// TODO this can be uncommented when #3325 has been fixed
		// Description: fieldDetails.Description,
	}, nil
}
