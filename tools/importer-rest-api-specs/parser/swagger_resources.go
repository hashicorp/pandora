package parser

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d *SwaggerDefinition) parseResourcesWithinSwaggerTag(tag *string) (*models.AzureApiResource, error) {
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	// note that Resource ID's can contain Constants (used as segments)
	resourceIds, err := d.findResourceIdsForTag(tag)
	if err != nil {
		return nil, fmt.Errorf("finding resource ids: %+v", err)
	}
	result.append(resourceIds.nestedResult)

	operations, nestedResult, err := d.parseOperationsWithinTag(tag, resourceIds.resourceUrisToMetadata, result)
	if err != nil {
		return nil, fmt.Errorf("finding operations: %+v", err)
	}
	result.append(*nestedResult)

	nestedResult, err = d.findNestedItemsYetToBeParsed(operations, result)
	if err != nil {
		return nil, fmt.Errorf("finding nested items yet to be parsed: %+v", err)
	}
	result.append(*nestedResult)

	// TODO: Actually parsing objects out Custom Type Switch-a-roo and Normalization

	// if there's nothing here, there's no point generating a package
	if len(*operations) == 0 && len(result.models) == 0 && len(result.constants) == 0 {
		return nil, nil
	}

	temporaryResourceIdMapForTestsToPass := make(map[string]string, 0)
	for k, v := range resourceIds.nameToResourceIDs {
		temporaryResourceIdMapForTestsToPass[k] = v.NormalizedResourceManagerResourceId()
	}

	resource := models.AzureApiResource{
		Constants:   result.constants,
		Models:      result.models,
		Operations:  *operations,
		ResourceIds: temporaryResourceIdMapForTestsToPass, // TODO: when we're further along this'll want to change
		//Operations:  *operations,
		//ResourceIds: resourceIds.NamesToResourceIds,
	}

	// first Normalize the names, meaning `foo` -> `Foo` for consistency
	//resource.Normalize()

	return &resource, nil
}

func (d *SwaggerDefinition) findNestedItemsYetToBeParsed(operations *map[string]models.OperationDetails, known parseResult) (*parseResult, error) {
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)

	// Now that we have a complete list of all of the nested items to find, loop around and find them
	// this is intentionaly not fetching nested models to avoid an infinite loop with Model1 referencing
	// Model2 which references Model1 (they instead get picked up in the next iteration)
	referencesToFind := d.determineObjectsRequiredButNotParsed(operations, result)
	for len(referencesToFind) > 0 {
		for _, referenceName := range referencesToFind {
			topLevelObject, err := d.findTopLevelObject(referenceName)
			if err != nil {
				return nil, fmt.Errorf("finding top level object named %q: %+v", referenceName, err)
			}

			parsedAsAConstant, constErr := mapConstant(topLevelObject.Type, topLevelObject.Enum, topLevelObject.Extensions)
			parsedAsAModel, modelErr := d.parseModel(referenceName, *topLevelObject)
			if (constErr != nil && modelErr != nil) || (constErr == nil && modelErr == nil) {
				return nil, fmt.Errorf("reference %q didn't parse as a Model or a Constant.\n\nConstant Error: %+v\n\nModel Error: %+v", referenceName, constErr, modelErr)
			}

			if parsedAsAConstant != nil {
				result.constants[parsedAsAConstant.name] = parsedAsAConstant.details
			}
			if parsedAsAModel != nil {
				result.append(*parsedAsAModel)
			}
		}

		referencesToFind = d.determineObjectsRequiredButNotParsed(operations, result)
	}

	return &result, nil
}

func (d *SwaggerDefinition) determineObjectsRequiredButNotParsed(operations *map[string]models.OperationDetails, known parseResult) []string {
	referencesToFind := make([]string, 0)
	for _, operation := range *operations {
		if operation.RequestObject != nil {
			topLevelRef := topLevelObjectDefinition(*operation.RequestObject)
			if topLevelRef.Type == models.ObjectDefinitionReference {
				isConstant, isModel := isObjectKnown(*topLevelRef.ReferenceName, known)
				if !isConstant && !isModel {
					referencesToFind = append(referencesToFind, *topLevelRef.ReferenceName)
				}

				if isModel {
					modelName := *topLevelRef.ReferenceName
					model := known.models[modelName]
					// if it's a model, we need to check all of the fields for this to find any constant or models
					// that we don't know about
					constantNamesToFind, modelNamesToFind := d.objectsUsedByModel(modelName, model)
					for _, constantName := range constantNamesToFind {
						if _, found := known.constants[constantName]; !found {
							referencesToFind = append(referencesToFind, constantName)
						}
					}
					for _, modelName := range modelNamesToFind {
						if _, found := known.models[modelName]; !found {
							referencesToFind = append(referencesToFind, modelName)
						}
					}
				}
			}
		}

		if operation.ResponseObject != nil {
			topLevelRef := topLevelObjectDefinition(*operation.ResponseObject)
			if topLevelRef.Type == models.ObjectDefinitionReference {
				isConstant, isModel := isObjectKnown(*topLevelRef.ReferenceName, known)
				if !isConstant && !isModel {
					referencesToFind = append(referencesToFind, *topLevelRef.ReferenceName)
				}

				if isModel {
					// if it's a model, we need to check all of the fields for this to find any constant or models
					// that we don't know about
					modelName := *topLevelRef.ReferenceName
					model := known.models[modelName]
					constantNamesToFind, modelNamesToFind := d.objectsUsedByModel(modelName, model)
					for _, constantName := range constantNamesToFind {
						if _, found := known.constants[constantName]; !found {
							referencesToFind = append(referencesToFind, constantName)
						}
					}
					for _, modelName := range modelNamesToFind {
						if _, found := known.models[modelName]; !found {
							referencesToFind = append(referencesToFind, modelName)
						}
					}
				}
			}
		}

		for _, value := range operation.Options {
			if value.ConstantObjectName == nil {
				continue
			}

			if _, isKnown := known.constants[*value.ConstantObjectName]; !isKnown {
				referencesToFind = append(referencesToFind, *value.ConstantObjectName)
			}
		}

	}

	return referencesToFind
}

func (d *SwaggerDefinition) objectsUsedByModel(modelName string, model models.ModelDetails) ([]string, []string) {
	constantNames := make([]string, 0)
	modelNames := make([]string, 0)

	for _, field := range model.Fields {
		if field.ConstantReference != nil {
			constantNames = append(constantNames, *field.ConstantReference)
		}
		if field.ModelReference != nil {
			modelNames = append(modelNames, *field.ModelReference)
		}
	}

	if model.AdditionalProperties != nil {
		if model.AdditionalProperties.ConstantReference != nil {
			constantNames = append(constantNames, *model.AdditionalProperties.ConstantReference)
		}

		if model.AdditionalProperties.ModelReference != nil {
			modelNames = append(modelNames, *model.AdditionalProperties.ModelReference)
		}
	}

	if model.ParentTypeName != nil {
		modelNames = append(modelNames, *model.ParentTypeName)
	}

	if model.TypeHintIn != nil {
		// this must be a discriminator
		modelNamesThatImplementThis := d.findModelNamesWhichImplement(modelName)
		modelNames = append(modelNames, modelNamesThatImplementThis...)
	}

	return constantNames, modelNames
}

func (d *SwaggerDefinition) findModelNamesWhichImplement(parentName string) []string {
	modelNames := make([]string, 0)

	for childName, value := range d.swaggerSpecExtendedRaw.Definitions {
		if childName == parentName {
			continue
		}

		// does it implement (AllOf) the base class
		implementsParent := false
		for _, parent := range value.AllOf {
			fragmentName := fragmentNameFromReference(parent.Ref)
			if fragmentName == nil {
				continue
			}

			if *fragmentName == parentName {
				implementsParent = true
				break
			}
		}
		if !implementsParent {
			continue
		}

		if d.debugLog {
			log.Printf("[DEBUG] Found %q implements %q", childName, parentName)
		}

		modelNames = append(modelNames, childName)
	}

	return modelNames
}

func isObjectKnown(name string, known parseResult) (bool, bool) {
	_, isConstant := known.constants[name]
	_, isModel := known.models[name]
	return isConstant, isModel
}

// topLevelObjectDefinition returns the top level object definition, that is a Constant or Model (or simple type) directly
func topLevelObjectDefinition(input models.ObjectDefinition) models.ObjectDefinition {
	if input.NestedItem != nil {
		return topLevelObjectDefinition(*input.NestedItem)
	}

	return input
}
