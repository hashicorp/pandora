// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cleanup

import (
	"strings"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func RemoveUnusedItems(input sdkModels.APIVersion) sdkModels.APIVersion {
	// The ordering matters here, we need to remove the ResourceIDs first since
	// they contain references to Constants - as do Models, so remove unused
	// Resource IDs, then Models, then Constants else we can have orphaned
	// constants within a package
	outputResources := make(map[string]sdkModels.APIResource)
	for resource, details := range input.Resources {
		resourceIdsForThisResource := make(map[string]sdkModels.ResourceID)
		for k, v := range details.ResourceIDs {
			resourceIdsForThisResource[k] = v
		}
		unusedResourceIds := findUnusedResourceIds(details.Operations, resourceIdsForThisResource)
		for len(unusedResourceIds) > 0 {
			for _, resourceIdName := range unusedResourceIds {
				delete(resourceIdsForThisResource, resourceIdName)
			}

			// then go around again
			unusedResourceIds = findUnusedResourceIds(details.Operations, resourceIdsForThisResource)
		}

		unusedModels := findUnusedModels(details.Operations, details.Models)
		for len(unusedModels) > 0 {
			// remove those models
			for _, modelName := range unusedModels {
				delete(details.Models, modelName)
			}

			// then go around again
			unusedModels = findUnusedModels(details.Operations, details.Models)
		}

		unusedConstants := findUnusedConstants(details.Operations, resourceIdsForThisResource, details.Models, details.Constants)
		for len(unusedConstants) > 0 {
			// remove those constants
			for _, constantName := range unusedConstants {
				delete(details.Constants, constantName)
			}

			// then go around again
			unusedConstants = findUnusedConstants(details.Operations, resourceIdsForThisResource, details.Models, details.Constants)
		}

		outputResources[resource] = sdkModels.APIResource{
			Constants:   details.Constants,
			Models:      details.Models,
			Operations:  details.Operations,
			ResourceIDs: resourceIdsForThisResource,
		}
	}

	input.Resources = outputResources
	return input
}

func findUnusedConstants(operations map[string]sdkModels.SDKOperation, resourceIds map[string]sdkModels.ResourceID, resourceModels map[string]sdkModels.SDKModel, resourceConstants map[string]sdkModels.SDKConstant) []string {
	unusedConstants := make(map[string]struct{})
	for constantName := range resourceConstants {
		// constants are either housed inside a Model
		usedInAModel := false
		for _, model := range resourceModels {
			for _, field := range model.Fields {
				definition := sdkHelpers.InnerMostSDKObjectDefinition(field.ObjectDefinition)
				if definition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
					continue
				}
				if *definition.ReferenceName == constantName {
					usedInAModel = true
					break
				}
			}

			if usedInAModel {
				break
			}
		}
		if usedInAModel {
			continue
		}

		usedInAnOperation := false
		for _, operation := range operations {
			if operation.RequestObject != nil {
				definition := sdkHelpers.InnerMostSDKObjectDefinition(*operation.RequestObject)
				if definition.Type == sdkModels.ReferenceSDKObjectDefinitionType && *definition.ReferenceName == constantName {
					usedInAnOperation = true
					break
				}
			}

			if operation.ResponseObject != nil {
				definition := sdkHelpers.InnerMostSDKObjectDefinition(*operation.ResponseObject)
				if definition.Type == sdkModels.ReferenceSDKObjectDefinitionType && *definition.ReferenceName == constantName {
					usedInAnOperation = true
					break
				}
			}

			for _, v := range operation.Options {
				definition := sdkHelpers.InnerMostSDKOperationOptionObjectDefinition(v.ObjectDefinition)
				if definition.Type != sdkModels.ReferenceSDKOperationOptionObjectDefinitionType {
					continue
				}
				if *definition.ReferenceName == constantName {
					usedInAnOperation = true
					break
				}
			}
		}
		if usedInAnOperation {
			continue
		}

		usedInAResourceId := false
		for _, rid := range resourceIds {
			for _, segment := range rid.Segments {
				if segment.ConstantReference == nil {
					continue
				}

				if strings.EqualFold(*segment.ConstantReference, constantName) {
					usedInAResourceId = true
					break
				}
			}

			if usedInAResourceId {
				break
			}
		}
		if usedInAResourceId {
			continue
		}

		unusedConstants[constantName] = struct{}{}
	}

	out := make([]string, 0)
	for k := range unusedConstants {
		out = append(out, k)
	}

	return out
}

func findUnusedModels(operations map[string]sdkModels.SDKOperation, resourceModels map[string]sdkModels.SDKModel) []string {
	unusedModels := make(map[string]struct{})
	for modelName, model := range resourceModels {
		if modelName == "" {
			// if the model name is empty this is an unused model (so is safe to remove) - but is a bug
			// TODO: track down empty models and then remove this
			unusedModels[modelName] = struct{}{}
			continue
		}

		// models are either referenced by operations
		usedInAnOperation := false
		for _, operation := range operations {
			if operation.RequestObject != nil {
				definition := sdkHelpers.InnerMostSDKObjectDefinition(*operation.RequestObject)
				if definition.Type == sdkModels.ReferenceSDKObjectDefinitionType && *definition.ReferenceName == modelName {
					usedInAnOperation = true
					break
				}
			}

			if operation.ResponseObject != nil {
				definition := sdkHelpers.InnerMostSDKObjectDefinition(*operation.ResponseObject)
				if definition.Type == sdkModels.ReferenceSDKObjectDefinitionType && *definition.ReferenceName == modelName {
					usedInAnOperation = true
					break
				}
			}

			// @tombuildsstuff: whilst I don't _think_ there are any examples of this today, checking it because it's an option
			for _, v := range operation.Options {
				definition := sdkHelpers.InnerMostSDKOperationOptionObjectDefinition(v.ObjectDefinition)
				if definition.Type != sdkModels.ReferenceSDKOperationOptionObjectDefinitionType {
					continue
				}
				if *definition.ReferenceName == modelName {
					usedInAnOperation = true
					continue
				}
			}
		}
		if usedInAnOperation {
			continue
		}

		// or on other models
		usedInAModel := false
		for thisModelName, thisModel := range resourceModels {
			if thisModelName == modelName {
				continue
			}

			for _, field := range thisModel.Fields {
				definition := sdkHelpers.InnerMostSDKObjectDefinition(field.ObjectDefinition)
				if definition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
					continue
				}
				if *definition.ReferenceName == modelName {
					usedInAModel = true
					break
				}
			}

			if thisModel.ParentTypeName != nil && *thisModel.ParentTypeName == modelName {
				// if this model inherits from the main type (e.g. discriminated) then it
				// should be kept
				usedInAModel = true
				break
			}
			if model.ParentTypeName != nil && *model.ParentTypeName == thisModelName {
				// likewise if it's the inverse
				usedInAModel = true
				break
			}
		}
		if usedInAModel {
			continue
		}

		unusedModels[modelName] = struct{}{}
	}

	out := make([]string, 0)
	for k := range unusedModels {
		out = append(out, k)
	}

	return out
}

func findUnusedResourceIds(operations map[string]sdkModels.SDKOperation, resourceIds map[string]sdkModels.ResourceID) []string {
	unusedResourceIds := make(map[string]struct{}, 0)

	// first add everything
	for name := range resourceIds {
		unusedResourceIds[name] = struct{}{}
	}

	// then go through and remove the Resource ID if it's used
	for _, operation := range operations {
		if operation.ResourceIDName == nil {
			continue
		}

		// since this hasn't been normalized yet, find the correct casing for the key to remove
		for key := range unusedResourceIds {
			if strings.EqualFold(*operation.ResourceIDName, key) {
				delete(unusedResourceIds, key)
			}
		}

	}

	output := make([]string, 0)
	for name := range unusedResourceIds {
		output = append(output, name)
	}

	return output
}
