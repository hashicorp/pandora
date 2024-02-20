package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapSDKFieldToRepository(fieldName string, fieldDetails resourcemanager.FieldDetails, isTypeHint bool, constants map[string]resourcemanager.ConstantDetails, knownModels map[string]resourcemanager.ModelDetails) (*dataapimodels.ModelField, error) {
	// TODO: thread through logging
	objectDefinition, err := mapSDKObjectDefinitionToRepository(fieldDetails.ObjectDefinition, constants, knownModels)
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
