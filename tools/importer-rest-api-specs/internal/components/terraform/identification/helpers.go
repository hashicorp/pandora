// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package identification

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func containsDiscriminatedTypes(terraformResource *sdkModels.TerraformResourceDefinition, apiResource sdkModels.APIResource) (*bool, error) {
	operationNames := make([]string, 0)
	if terraformResource != nil {
		operationNames = append(operationNames, []string{
			terraformResource.CreateMethod.SDKOperationName,
			terraformResource.DeleteMethod.SDKOperationName,
			terraformResource.ReadMethod.SDKOperationName,
		}...)
		if terraformResource.UpdateMethod != nil {
			operationNames = append(operationNames, terraformResource.UpdateMethod.SDKOperationName)
		}
	}
	for _, operationName := range operationNames {
		operation, ok := apiResource.Operations[operationName]
		if !ok {
			return nil, fmt.Errorf("the operation named %q was not found", operationName)
		}

		if operation.RequestObject != nil {
			if operation.RequestObject.Type != sdkModels.ReferenceSDKObjectDefinitionType {
				return nil, fmt.Errorf("request objects must use a reference but got %q", string(operation.RequestObject.Type))
			}
			modelName := *operation.RequestObject.ReferenceName
			model, ok := apiResource.Models[modelName]
			if !ok {
				return nil, fmt.Errorf("the Model %q used for the %q operation Request Object was not found", modelName, operationName)
			}
			result := modelContainsDiscriminatedTypes(model, apiResource)
			if result {
				return pointer.FromBool(true), nil
			}
		}
	}

	return pointer.FromBool(false), nil
}

func modelContainsDiscriminatedTypes(model sdkModels.SDKModel, apiResource sdkModels.APIResource) bool {
	if model.ParentTypeName != nil || model.FieldNameContainingDiscriminatedValue != nil || model.DiscriminatedValue != nil {
		return true
	}

	for _, field := range model.Fields {
		if field.ContainsDiscriminatedValue {
			return true
		}

		topLevelObjectDefinition := sdkHelpers.InnerMostSDKObjectDefinition(field.ObjectDefinition)
		if topLevelObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
			continue
		}
		nestedModel, isNestedModel := apiResource.Models[*topLevelObjectDefinition.ReferenceName]
		if !isNestedModel {
			// assume it's a constant
			continue
		}
		nestedModelIsDiscriminator := modelContainsDiscriminatedTypes(nestedModel, apiResource)
		if nestedModelIsDiscriminator {
			return true
		}
	}

	return false
}
