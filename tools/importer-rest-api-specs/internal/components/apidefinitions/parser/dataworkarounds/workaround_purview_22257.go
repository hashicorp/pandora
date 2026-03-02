package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// workaroundPurview22257 is a workaround to fix the type of Identity sent to the API.
// The api specs imply that the correct types for Identity should be "system OR user".
// The actual API for purview requires the use of "system AND user" when specifying "user".
// This inconsistency is mentioned in the following open issue:https://github.com/Azure/azure-rest-api-specs/issues/22257
type workaroundPurview22257 struct{}

func (w workaroundPurview22257) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "Purview"
	apiVersionMatches := apiVersion.APIVersion == "2021-07-01" || apiVersion.APIVersion == "2021-12-01"
	return serviceMatches && apiVersionMatches
}

func (w workaroundPurview22257) Name() string {
	return "Purview / 22257"
}

func (w workaroundPurview22257) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Account"]
	if !ok {
		return nil, errors.New("expected to find the API Resource `Purview Account`")
	}

	modelNames := []string{"Account", "AccountUpdateParameters"}
	for _, modelName := range modelNames {
		model, ok := resource.Models[modelName]
		if !ok {
			return nil, fmt.Errorf("expected the API Resource `Purview` to contain Model `%s`", modelName)
		}

		field, ok := model.Fields["Identity"]
		if !ok {
			return nil, errors.New("expected the Model `Account` to contain a field `Identity`")
		}

		// update the reference to be a System AND UserAssigned identity
		field.ObjectDefinition = sdkModels.SDKObjectDefinition{
			Type: sdkModels.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
		}

		model.Fields["Identity"] = field
		resource.Models[modelName] = model
	}
	input.Resources["Account"] = resource

	return &input, nil
}
