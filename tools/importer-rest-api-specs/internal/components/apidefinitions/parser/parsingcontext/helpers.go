package parsingcontext

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func fragmentNameFromReference(input spec.Ref) *string {
	fragmentName := input.String()
	return fragmentNameFromString(fragmentName)
}

func fragmentNameFromString(fragmentName string) *string {
	if fragmentName != "" {
		fragments := strings.Split(fragmentName, "/") // format #/definitions/ConfigurationStoreListResult
		referenceName := fragments[len(fragments)-1]
		return &referenceName
	}

	return nil
}

func inlinedModelName(parentModelName, fieldName string) string {
	// intentionally split out for consistency
	val := fmt.Sprintf("%s%s", cleanup.Title(parentModelName), cleanup.Title(fieldName))
	return cleanup.NormalizeName(val)
}

func operationMatchesTag(operation *spec.Operation, tag *string) bool {
	// if there's no tags defined, we should capture it when the tag matched
	if tag == nil {
		return len(operation.Tags) == 0
	}

	for _, thisTag := range operation.Tags {
		if strings.EqualFold(thisTag, *tag) {
			return true
		}
	}

	return false
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

func isFieldRequired(name string, required map[string]struct{}) bool {
	for k := range required {
		// assume data inconsistencies
		if strings.EqualFold(k, name) {
			return true
		}
	}

	return false
}

func (c *Context) FindNestedItemsYetToBeParsed(operations map[string]sdkModels.SDKOperation, known parserModels.ParseResult) (*parserModels.ParseResult, error) {
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	// Now that we have a complete list of all the nested items to find, loop around and find them
	// this is intentionally not fetching nested models to avoid an infinite loop with Model1 referencing
	// Model2 which references Model1 (they instead get picked up in the next iteration)
	referencesToFind, err := c.determineObjectsRequiredButNotParsed(operations, result)
	if err != nil {
		return nil, fmt.Errorf("determining objects required but not parsed: %+v", err)
	}
	for len(*referencesToFind) > 0 {
		for _, referenceName := range *referencesToFind {
			topLevelObject, err := c.findTopLevelObject(referenceName)
			if err != nil {
				return nil, fmt.Errorf("finding top level object named %q: %+v", referenceName, err)
			}

			parsedAsAConstant, constErr := constants.Parse(topLevelObject.Type, referenceName, nil, topLevelObject.Enum, topLevelObject.Extensions)
			parsedAsAModel, modelErr := c.ParseModel(referenceName, *topLevelObject)
			if (constErr != nil && modelErr != nil) || (parsedAsAConstant == nil && parsedAsAModel == nil) {
				return nil, fmt.Errorf("reference %q didn't parse as a Model or a Constant.\n\nConstant Error: %+v\n\nModel Error: %+v", referenceName, constErr, modelErr)
			}

			if parsedAsAConstant != nil {
				result.Constants[parsedAsAConstant.Name] = parsedAsAConstant.Details
			}
			if parsedAsAModel != nil {
				if err := result.Append(*parsedAsAModel); err != nil {
					return nil, fmt.Errorf("appending model: %+v", err)
				}
			}
		}

		remainingReferencesToFind, err := c.determineObjectsRequiredButNotParsed(operations, result)
		if err != nil {
			return nil, fmt.Errorf("determining objects required but not parsed: %+v", err)
		}
		if referencesAreTheSame(*referencesToFind, *remainingReferencesToFind) {
			return nil, fmt.Errorf("the following references couldn't be found: %q", strings.Join(*referencesToFind, ", "))
		}
		referencesToFind = remainingReferencesToFind
	}

	return &result, nil
}

func (c *Context) determineObjectsRequiredButNotParsed(operations map[string]sdkModels.SDKOperation, known parserModels.ParseResult) (*[]string, error) {
	referencesToFind := make(map[string]struct{})

	for _, operation := range operations {
		if operation.RequestObject != nil {
			topLevelRef := sdkHelpers.InnerMostSDKObjectDefinition(*operation.RequestObject)
			if topLevelRef.Type == sdkModels.ReferenceSDKObjectDefinitionType {
				isKnownConstant, isKnownModel := known.IsObjectKnown(*topLevelRef.ReferenceName)
				if !isKnownConstant && !isKnownModel {
					referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
				}

				if isKnownModel {
					modelName := *topLevelRef.ReferenceName
					model := known.Models[modelName]
					missingReferencesInModel, err := c.objectsRequiredByModel(modelName, model, known)
					if err != nil {
						return nil, fmt.Errorf("determining objects required by model %q: %+v", modelName, err)
					}
					for _, name := range *missingReferencesInModel {
						referencesToFind[name] = struct{}{}
					}
				}
			}
		}

		if operation.ResponseObject != nil {
			topLevelRef := sdkHelpers.InnerMostSDKObjectDefinition(*operation.ResponseObject)
			if topLevelRef.Type == sdkModels.ReferenceSDKObjectDefinitionType {
				isKnownConstant, isKnownModel := known.IsObjectKnown(*topLevelRef.ReferenceName)
				if !isKnownConstant && !isKnownModel {
					referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
				}

				if isKnownModel {
					// if it's a model, we need to check all the fields for this to find any constant or models
					// that we don't know about
					modelName := *topLevelRef.ReferenceName
					model := known.Models[modelName]
					missingReferencesInModel, err := c.objectsRequiredByModel(modelName, model, known)
					if err != nil {
						return nil, fmt.Errorf("determining objects required by model %q: %+v", modelName, err)
					}
					for _, name := range *missingReferencesInModel {
						referencesToFind[name] = struct{}{}
					}
				}
			}
		}

		for _, value := range operation.Options {
			topLevelRef := sdkHelpers.InnerMostSDKOperationOptionObjectDefinition(value.ObjectDefinition)
			if topLevelRef.Type != sdkModels.ReferenceSDKOperationOptionObjectDefinitionType {
				continue
			}

			if _, isKnown := known.Constants[*topLevelRef.ReferenceName]; !isKnown {
				referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
			}
		}
	}

	// then verify we have each of the models for the current models we know about
	for modelName, model := range known.Models {
		missingReferencesInModel, err := c.objectsRequiredByModel(modelName, model, known)
		if err != nil {
			return nil, fmt.Errorf("determining objects required by model %q: %+v", modelName, err)
		}
		for _, name := range *missingReferencesInModel {
			referencesToFind[name] = struct{}{}
		}
	}

	out := make([]string, 0)
	for k := range referencesToFind {
		if _, exists := known.Constants[k]; exists {
			continue
		}
		if _, exists := known.Models[k]; exists {
			continue
		}

		out = append(out, k)
	}

	return &out, nil
}

func (c *Context) objectsUsedByModel(modelName string, model sdkModels.SDKModel) (*[]string, error) {
	typeNames := make(map[string]struct{}, 0)

	for fieldName, field := range model.Fields {
		logging.Tracef("Determining objects used by field %q..", fieldName)
		definition := sdkHelpers.InnerMostSDKObjectDefinition(field.ObjectDefinition)
		if definition.ReferenceName != nil {
			typeNames[*definition.ReferenceName] = struct{}{}
		}
	}

	if model.ParentTypeName != nil {
		typeNames[*model.ParentTypeName] = struct{}{}
	}

	if model.FieldNameContainingDiscriminatedValue != nil {
		// this must be a discriminator
		modelNamesThatImplementThis, err := c.findModelNamesWhichImplement(modelName)
		if err != nil {
			return nil, fmt.Errorf("finding models which implement %q: %+v", modelName, err)
		}
		for _, k := range *modelNamesThatImplementThis {
			typeNames[k] = struct{}{}
		}
	}

	out := make([]string, 0)
	for k := range typeNames {
		out = append(out, k)
	}
	return &out, nil
}

func (c *Context) objectsRequiredByModel(modelName string, model sdkModels.SDKModel, known parserModels.ParseResult) (*[]string, error) {
	result := make(map[string]struct{})
	// if it's a model, we need to check each of the fields for this to find any constant or models
	// that we don't know about
	logging.Tracef("Determining the Objects used by the Model %q..", modelName)
	typesToFind, err := c.objectsUsedByModel(modelName, model)
	if err != nil {
		return nil, fmt.Errorf("determining objects used by model %q: %+v", modelName, err)
	}
	logging.Tracef("Found %d items: %+v", len(*typesToFind), *typesToFind)
	for _, typeName := range *typesToFind {
		_, existingConstant := known.Constants[typeName]
		_, existingModel := known.Models[typeName]
		if !existingConstant && !existingModel {
			result[typeName] = struct{}{}
		}
	}

	out := make([]string, 0)
	for k := range result {
		out = append(out, k)
	}
	return &out, nil
}
