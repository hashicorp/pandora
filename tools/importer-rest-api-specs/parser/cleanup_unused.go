package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

func (d *SwaggerDefinition) removeUnusedModelsAndConstants(resources map[string]models.AzureApiResource) {
	for _, resource := range resources {
		unusedModels := d.findUnusedModels(resource)
		for len(unusedModels) > 0 {
			// remove those models
			for _, modelName := range unusedModels {
				delete(resource.Models, modelName)
			}

			// then go around again
			unusedModels = d.findUnusedModels(resource)
		}

		unusedConstants := d.findUnusedConstants(resource)
		for len(unusedConstants) > 0 {
			// remove those constants
			for _, constantName := range unusedConstants {
				delete(resource.Constants, constantName)
			}

			// then go around again
			unusedConstants = d.findUnusedConstants(resource)
		}

		// TODO: presumably we should check for Resource ID's here in the future when implementing #13
	}
}

func (d *SwaggerDefinition) findUnusedConstants(input models.AzureApiResource) []string {
	unusedConstants := make([]string, 0)
	for constantName := range input.Constants {
		// constants are either housed inside a Model
		usedInAModel := false
		for _, model := range input.Models {
			for _, field := range model.Fields {
				if field.ConstantReference == nil {
					continue
				}

				if *field.ConstantReference == constantName {
					usedInAModel = true
					break
				}
			}

			// is this referenced as a dictionary
			if model.AdditionalProperties != nil {
				if model.AdditionalProperties.ConstantReference != nil && *model.AdditionalProperties.ConstantReference == constantName {
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
		for _, operation := range input.Operations {
			if operation.RequestObject != nil && operation.RequestObject.Type == models.ObjectDefinitionReference && *operation.RequestObject.ReferenceName == constantName {
				usedInAnOperation = true
				break
			}

			if operation.ResponseObject != nil && operation.ResponseObject.Type == models.ObjectDefinitionReference && *operation.ResponseObject.ReferenceName == constantName {
				usedInAnOperation = true
				break
			}

			for _, option := range operation.Options {
				if option.ConstantObjectName == nil {
					continue
				}

				if *option.ConstantObjectName == constantName {
					usedInAnOperation = true
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

func (d *SwaggerDefinition) findUnusedModels(input models.AzureApiResource) []string {
	unusedModels := make([]string, 0)
	for modelName, model := range input.Models {
		if modelName == "" {
			panic("empty model name")
		}

		// models are either referenced by operations
		usedInAnOperation := false
		for _, operation := range input.Operations {
			if d.modelIsUsedInObjectDefinition(modelName, operation.RequestObject) {
				usedInAnOperation = true
				break
			}

			if d.modelIsUsedInObjectDefinition(modelName, operation.ResponseObject) {
				usedInAnOperation = true
				break
			}

			// TODO: can these be in Options in the future too? confirm as a part of #19
		}
		if usedInAnOperation {
			continue
		}

		// or on other models
		usedInAModel := false
		for thisModelName, thisModel := range input.Models {
			if thisModelName == modelName {
				continue
			}

			for _, field := range thisModel.Fields {
				if field.ModelReference != nil && *field.ModelReference == modelName {
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

			// is this referenced as a dictionary
			if thisModel.AdditionalProperties != nil {
				if thisModel.AdditionalProperties.ModelReference != nil && *thisModel.AdditionalProperties.ModelReference == modelName {
					usedInAModel = true
					break
				}
			}
		}
		if usedInAModel {
			continue
		}

		unusedModels = append(unusedModels, modelName)
	}
	return unusedModels
}

func (d *SwaggerDefinition) modelIsUsedInObjectDefinition(modelName string, definition *models.ObjectDefinition) bool {
	if definition == nil {
		return false
	}

	if definition.Type == models.ObjectDefinitionList || definition.Type == models.ObjectDefinitionDictionary {
		// this should be caught elsewhere, but rather than panic returning false will mean this is stripped out
		// which shows as a compiler error, which should give us _all_ of the operations where this is an issue
		// so we can account for it
		if definition.NestedItem == nil {
			return false
		}

		return d.modelIsUsedInObjectDefinition(modelName, definition.NestedItem)
	}

	return definition.ReferenceName != nil && *definition.ReferenceName == modelName
}
