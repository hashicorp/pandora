package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

func removeUnusedItems(operations map[string]models.OperationDetails, result parseResult) parseResult {
	unusedModels := findUnusedModels(operations, result)
	for len(unusedModels) > 0 {
		// remove those models
		for _, modelName := range unusedModels {
			delete(result.models, modelName)
		}

		// then go around again
		unusedModels = findUnusedModels(operations, result)
	}

	unusedConstants := findUnusedConstants(operations, result)
	for len(unusedConstants) > 0 {
		// remove those constants
		for _, constantName := range unusedConstants {
			delete(result.constants, constantName)
		}

		// then go around again
		unusedConstants = findUnusedConstants(operations, result)
	}

	return result
}

func findUnusedConstants(operations map[string]models.OperationDetails, result parseResult) []string {
	unusedConstants := make([]string, 0)
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

		unusedConstants = append(unusedConstants, constantName)
	}

	return unusedConstants
}

func findUnusedModels(operations map[string]models.OperationDetails, result parseResult) []string {
	unusedModels := make([]string, 0)
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

		unusedModels = append(unusedModels, modelName)
	}
	return unusedModels
}
