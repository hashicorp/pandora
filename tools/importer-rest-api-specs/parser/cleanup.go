package parser

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func removeUnusedItems(operations map[string]models.OperationDetails, resourceIds map[string]models.ParsedResourceId, result parseResult) parseResult {
	unusedModels := findUnusedModels(operations, result)
	for len(unusedModels) > 0 {
		// remove those models
		for _, modelName := range unusedModels {
			delete(result.models, modelName)
		}

		// then go around again
		unusedModels = findUnusedModels(operations, result)
	}

	unusedConstants := findUnusedConstants(operations, resourceIds, result)
	for len(unusedConstants) > 0 {
		// remove those constants
		for _, constantName := range unusedConstants {
			delete(result.constants, constantName)
		}

		// then go around again
		unusedConstants = findUnusedConstants(operations, resourceIds, result)
	}

	unusedResourceIds := findUnusedResourceIds(operations, resourceIds)
	for len(unusedResourceIds) > 0 {
		for _, resourceIdName := range unusedResourceIds {
			delete(resourceIds, resourceIdName)
		}

		// then go around again
		unusedResourceIds = findUnusedResourceIds(operations, resourceIds)
	}

	return result
}

func findUnusedConstants(operations map[string]models.OperationDetails, resourceIds map[string]models.ParsedResourceId, result parseResult) []string {
	unusedConstants := make(map[string]struct{}, 0)
	for constantName := range result.constants {
		// constants are either housed inside a Model
		usedInAModel := false
		for _, model := range result.models {
			for _, field := range model.Fields {
				if field.ObjectDefinition == nil {
					continue
				}
				definition := topLevelObjectDefinition(*field.ObjectDefinition)
				if definition.Type != models.ObjectDefinitionReference {
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
				definition := topLevelObjectDefinition(*operation.RequestObject)
				if definition.Type == models.ObjectDefinitionReference && *definition.ReferenceName == constantName {
					usedInAnOperation = true
					break
				}
			}

			if operation.ResponseObject != nil {
				definition := topLevelObjectDefinition(*operation.ResponseObject)
				if definition.Type == models.ObjectDefinitionReference && *definition.ReferenceName == constantName {
					usedInAnOperation = true
					break
				}
			}

			for _, v := range operation.Options {
				if v.ObjectDefinition == nil {
					continue
				}

				definition := topLevelObjectDefinition(*v.ObjectDefinition)
				if definition.Type != models.ObjectDefinitionReference {
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

func findUnusedModels(operations map[string]models.OperationDetails, result parseResult) []string {
	unusedModels := make(map[string]struct{}, 0)
	for modelName, model := range result.models {
		// models are either referenced by operations
		usedInAnOperation := false
		for _, operation := range operations {
			if operation.RequestObject != nil {
				definition := topLevelObjectDefinition(*operation.RequestObject)
				if definition.Type == models.ObjectDefinitionReference && *definition.ReferenceName == modelName {
					usedInAnOperation = true
					break
				}
			}

			if operation.ResponseObject != nil {
				definition := topLevelObjectDefinition(*operation.ResponseObject)
				if definition.Type == models.ObjectDefinitionReference && *definition.ReferenceName == modelName {
					usedInAnOperation = true
					break
				}
			}

			// @tombuildsstuff: whilst I don't _think_ there are any examples of this today, checking it because it's an option
			for _, v := range operation.Options {
				if v.ObjectDefinition == nil {
					continue
				}

				definition := topLevelObjectDefinition(*v.ObjectDefinition)
				if definition.Type != models.ObjectDefinitionReference {
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
		for thisModelName, thisModel := range result.models {
			if thisModelName == modelName {
				continue
			}

			for _, field := range thisModel.Fields {
				if field.ObjectDefinition == nil {
					continue
				}

				definition := topLevelObjectDefinition(*field.ObjectDefinition)
				if definition.Type != models.ObjectDefinitionReference {
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

func findUnusedResourceIds(operations map[string]models.OperationDetails, resourceIds map[string]models.ParsedResourceId) []string {
	unusedResourceIds := make(map[string]struct{}, 0)

	// first add everything
	for name := range resourceIds {
		unusedResourceIds[name] = struct{}{}
	}

	// then go through and remove the Resource ID if it's used
	for _, operation := range operations {
		if operation.ResourceIdName == nil {
			continue
		}

		delete(unusedResourceIds, *operation.ResourceIdName)
	}

	output := make([]string, 0)
	for name := range unusedResourceIds {
		output = append(output, name)
	}

	return output
}