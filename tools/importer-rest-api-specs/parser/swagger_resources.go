package parser

import (
	"fmt"
	"log"
	"strings"

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

	// TODO: Custom Type Switch-a-roo and clean up any unused

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
	resource.Normalize()

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
			if (constErr != nil && modelErr != nil) || (parsedAsAConstant == nil && parsedAsAModel == nil) {
				return nil, fmt.Errorf("reference %q didn't parse as a Model or a Constant.\n\nConstant Error: %+v\n\nModel Error: %+v", referenceName, constErr, modelErr)
			}

			if parsedAsAConstant != nil {
				result.constants[parsedAsAConstant.name] = parsedAsAConstant.details
			}
			if parsedAsAModel != nil {
				result.append(*parsedAsAModel)
			}
		}

		remainingReferencesToFind := d.determineObjectsRequiredButNotParsed(operations, result)
		if referencesAreTheSame(referencesToFind, remainingReferencesToFind) {
			return nil, fmt.Errorf("the following references couldn't be found: %q", strings.Join(referencesToFind, ", "))
		}
		referencesToFind = remainingReferencesToFind
	}

	return &result, nil
}

func referencesAreTheSame(first []string, second []string) bool {
	if len(first) != len(second) {
		return false
	}

	// first load the existing keys
	keys := make(map[string]struct{}, 0)
	for _, key := range first {
		keys[key] = struct{}{}
	}

	// then check the remaining ones
	for _, key := range second {
		if _, exists := keys[key]; !exists {
			return false
		}
	}

	return true
}

func (d *SwaggerDefinition) determineObjectsRequiredButNotParsed(operations *map[string]models.OperationDetails, known parseResult) []string {
	referencesToFind := make(map[string]struct{}, 0)

	var objectsRequiredByModel = func(modelName string, model models.ModelDetails) []string {
		result := make(map[string]struct{}, 0)
		// if it's a model, we need to check all of the fields for this to find any constant or models
		// that we don't know about
		typesToFind := d.objectsUsedByModel(modelName, model)
		for _, typeName := range typesToFind {
			_, existingConstant := known.constants[typeName]
			_, existingModel := known.models[typeName]
			if !existingConstant && existingModel {
				result[typeName] = struct{}{}
			}
		}

		out := make([]string, 0)
		for k := range result {
			out = append(out, k)
		}
		return out
	}

	for _, operation := range *operations {
		if operation.RequestObject != nil {
			topLevelRef := topLevelObjectDefinition(*operation.RequestObject)
			if topLevelRef.Type == models.ObjectDefinitionReference {
				isKnownConstant, isKnownModel := isObjectKnown(*topLevelRef.ReferenceName, known)
				if !isKnownConstant && !isKnownModel {
					referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
				}

				if isKnownModel {
					modelName := *topLevelRef.ReferenceName
					model := known.models[modelName]
					missingReferencesInModel := objectsRequiredByModel(modelName, model)
					for _, name := range missingReferencesInModel {
						referencesToFind[name] = struct{}{}
					}
				}
			}
		}

		if operation.ResponseObject != nil {
			topLevelRef := topLevelObjectDefinition(*operation.ResponseObject)
			if topLevelRef.Type == models.ObjectDefinitionReference {
				isKnownConstant, isKnownModel := isObjectKnown(*topLevelRef.ReferenceName, known)
				if !isKnownConstant && !isKnownModel {
					referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
				}

				if isKnownModel {
					// if it's a model, we need to check all of the fields for this to find any constant or models
					// that we don't know about
					modelName := *topLevelRef.ReferenceName
					model := known.models[modelName]
					missingReferencesInModel := objectsRequiredByModel(modelName, model)
					for _, name := range missingReferencesInModel {
						referencesToFind[name] = struct{}{}
					}
				}
			}
		}

		for _, value := range operation.Options {
			if value.ObjectDefinition == nil {
				continue
			}

			topLevelRef := topLevelObjectDefinition(*value.ObjectDefinition)
			if topLevelRef.Type != models.ObjectDefinitionReference {
				continue
			}

			if _, isKnown := known.constants[*topLevelRef.ReferenceName]; !isKnown {
				referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
			}
		}
	}

	// then verify we have all of the models for the current models we know about
	for modelName, model := range known.models {
		missingReferencesInModel := objectsRequiredByModel(modelName, model)
		for _, name := range missingReferencesInModel {
			referencesToFind[name] = struct{}{}
		}
	}

	out := make([]string, 0)
	for k := range referencesToFind {
		if _, exists := known.constants[k]; exists {
			continue
		}
		if _, exists := known.models[k]; exists {
			continue
		}
		
		out = append(out, k)
	}

	return out
}

func (d *SwaggerDefinition) objectsUsedByModel(modelName string, model models.ModelDetails) []string {
	typeNames := make(map[string]struct{}, 0)

	for _, field := range model.Fields {
		if field.ObjectDefinition == nil {
			continue
		}

		definition := topLevelObjectDefinition(*field.ObjectDefinition)
		if definition.ReferenceName != nil {
			typeNames[*definition.ReferenceName] = struct{}{}
		}
	}

	if model.ParentTypeName != nil {
		typeNames[*model.ParentTypeName] = struct{}{}
	}

	if model.TypeHintIn != nil {
		// this must be a discriminator
		modelNamesThatImplementThis := d.findModelNamesWhichImplement(modelName)
		for _, k := range modelNamesThatImplementThis {
			typeNames[k] = struct{}{}
		}
	}

	out := make([]string, 0)
	for k := range typeNames {
		out = append(out, k)
	}
	return out
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
