// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resources

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// FindCandidates returns a list of candidate Data Sources and Resources
// within the specified Service
func FindCandidates(apiResource models.APIResource, resourceDefinitions map[string]definitions.ResourceDefinition, apiResourceName string, logger hclog.Logger) (*resourcemanager.TerraformDetails, error) {
	out := resourcemanager.TerraformDetails{
		Resources: map[string]resourcemanager.TerraformResourceDetails{},
	}

	for resourceIdName, resourceId := range apiResource.ResourceIDs {
		var createMethod *models.TerraformMethodDefinition
		var updateMethod *models.TerraformMethodDefinition
		var deleteMethod *models.TerraformMethodDefinition
		var getMethod *models.TerraformMethodDefinition

		resourceIDDisplayValue := helpers.DisplayValueForResourceID(resourceId)
		resourceLabel, resourceMetaData := findResourceName(resourceDefinitions, resourceIDDisplayValue)
		if resourceLabel == nil || resourceMetaData == nil {
			logger.Debug(fmt.Sprintf("Identified Resource %q but not defined - skipping", resourceIDDisplayValue))
			continue
		}

		for operationName, operation := range apiResource.Operations {
			// if it's an operation on just a suffix we're not interested
			if operation.ResourceIDName == nil {
				continue
			}
			if *operation.ResourceIDName != resourceIdName {
				continue
			}

			if (strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT")) && operation.URISuffix == nil && operation.RequestObject != nil {
				createMethod = &models.TerraformMethodDefinition{
					Generate:         resourceMetaData.GenerateCreate,
					SDKOperationName: operationName,
					TimeoutInMinutes: 30,
				}
			}
			if strings.EqualFold(operation.Method, "PATCH") && operation.URISuffix == nil && operation.RequestObject != nil {
				v := strings.ToLower(operationName)
				// if this is UpdateTags etc, ignore it since the model will be totally unrelated
				if v != "update" && strings.HasPrefix(v, "update") {
					continue
				}
				objectDefinition := helpers.InnerMostSDKObjectDefinition(*operation.RequestObject)
				if objectDefinition.Type != models.ReferenceSDKObjectDefinitionType {
					continue
				}
				model, ok := apiResource.Models[*objectDefinition.ReferenceName]
				if !ok {
					return nil, fmt.Errorf("the request model %q for operation %q was not found", *objectDefinition.ReferenceName, operationName)
				}
				_, hasPropertiesField := model.Fields["Properties"]
				if !hasPropertiesField {
					continue
				}

				updateMethod = &models.TerraformMethodDefinition{
					Generate:         resourceMetaData.GenerateUpdate,
					SDKOperationName: operationName,
					TimeoutInMinutes: 30,
				}
			}
			if strings.EqualFold(operation.Method, "GET") && operation.URISuffix == nil && operation.ResponseObject != nil {
				if operation.URISuffix == nil {
					getMethod = &models.TerraformMethodDefinition{
						Generate:         resourceMetaData.GenerateRead,
						SDKOperationName: operationName,
						TimeoutInMinutes: 5,
					}
				}
			}
			if strings.EqualFold(operation.Method, "DELETE") && operation.URISuffix == nil {
				deleteMethod = &models.TerraformMethodDefinition{
					Generate:         resourceMetaData.GenerateDelete,
					SDKOperationName: operationName,
					TimeoutInMinutes: 30,
				}
			}
			// TODO: determine if we're concerned with these in the future (e.g. ListKeys etc)
			//if operation.URISuffix != nil && !strings.EqualFold(operation.Method, "GET") {
			//	hasSuffixedMethods = true
			//}
		}

		// once we've been over all the methods, check if the Create method is actually CreateOrUpdate
		if updateMethod == nil && createMethod != nil {
			// handle CreateOrUpdate, but only when there's no Update method
			if strings.Contains(strings.ToLower(createMethod.SDKOperationName), "update") {
				updateMethod = &models.TerraformMethodDefinition{
					Generate:         resourceMetaData.GenerateUpdate,
					SDKOperationName: createMethod.SDKOperationName,
					TimeoutInMinutes: 30,
				}
			}
		}

		var resourceDefinition *resourcemanager.TerraformResourceDetails
		if createMethod != nil && getMethod != nil && deleteMethod != nil {
			resourceDefinition = &resourcemanager.TerraformResourceDetails{
				CreateMethod:         *createMethod,
				DeleteMethod:         *deleteMethod,
				DisplayName:          resourceMetaData.Name,
				Generate:             true,
				GenerateSchema:       true,
				GenerateIdValidation: true,
				GenerateModel:        true,
				ReadMethod:           *getMethod,
				Resource:             apiResourceName,
				ResourceIdName:       resourceIdName,
				ResourceName:         strings.ReplaceAll(resourceMetaData.Name, " ", ""), // TODO: maybe more later
				UpdateMethod:         updateMethod,
				Documentation: models.TerraformDocumentationDefinition{
					Category:    resourceMetaData.WebsiteSubcategory,
					Description: resourceMetaData.Description,
				},
				Tests: resourcemanager.TerraformResourceTestsDefinition{
					Generate: true,
					TestData: &resourcemanager.TerraformResourceTestDataDefinition{
						BasicVariables: resourcemanager.TerraformTestDataVariables{
							Bools:    resourceMetaData.TestData.BasicVariables.Bools,
							Integers: resourceMetaData.TestData.BasicVariables.Integers,
							Lists:    resourceMetaData.TestData.BasicVariables.Lists,
							Strings:  resourceMetaData.TestData.BasicVariables.Strings,
						},
						CompleteVariables: resourcemanager.TerraformTestDataVariables{
							Bools:    resourceMetaData.TestData.CompleteVariables.Bools,
							Integers: resourceMetaData.TestData.CompleteVariables.Integers,
							Lists:    resourceMetaData.TestData.CompleteVariables.Lists,
							Strings:  resourceMetaData.TestData.CompleteVariables.Strings,
						},
					},
				},
			}
		}
		hasDiscriminatedType, err := containsDiscriminatedTypes(resourceDefinition, apiResource)
		if err != nil {
			return nil, fmt.Errorf("determining if the Resource Definition for %q contains Discriminated Types: %+v", resourceIDDisplayValue, err)
		}
		if *hasDiscriminatedType {
			logger.Debug(fmt.Sprintf("Resource %q is/contains a Discriminated Type - not supported at this time", resourceIDDisplayValue))
			continue
		}

		if resourceDefinition != nil {
			out.Resources[*resourceLabel] = *resourceDefinition
		}
	}

	return &out, nil
}

func containsDiscriminatedTypes(terraformResource *resourcemanager.TerraformResourceDetails, apiResource models.APIResource) (*bool, error) {
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
			if operation.RequestObject.Type != models.ReferenceSDKObjectDefinitionType {
				return nil, fmt.Errorf("request objects must use a reference but got %q", string(operation.RequestObject.Type))
			}
			modelName := *operation.RequestObject.ReferenceName
			model, ok := apiResource.Models[modelName]
			if !ok {
				return nil, fmt.Errorf("the Model %q used for the %q operation Request Object was not found", modelName, operationName)
			}
			containsDiscriminatedTypes := modelContainsDiscriminatedTypes(model, apiResource)
			if containsDiscriminatedTypes {
				return pointer.FromBool(true), nil
			}
		}
	}

	return pointer.FromBool(false), nil
}

func modelContainsDiscriminatedTypes(model models.SDKModel, apiResource models.APIResource) bool {
	if model.ParentTypeName != nil || model.FieldNameContainingDiscriminatedValue != nil || model.DiscriminatedValue != nil {
		return true
	}

	for _, field := range model.Fields {
		if field.ContainsDiscriminatedValue {
			return true
		}

		topLevelObjectDefinition := helpers.InnerMostSDKObjectDefinition(field.ObjectDefinition)
		if topLevelObjectDefinition.Type != models.ReferenceSDKObjectDefinitionType {
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

func findResourceName(definitions map[string]definitions.ResourceDefinition, resourceId string) (*string, *definitions.ResourceDefinition) {
	for k, v := range definitions {
		if v.ID == resourceId {
			return &k, &v
		}
	}

	return nil, nil
}
