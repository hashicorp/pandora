// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"fmt"
	"log"
	"net/url"
	"strings"

	"github.com/getkin/kin-openapi/openapi2"
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/go-openapi/spec"
	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func fragmentNameFromReference(input openapi2.SchemaRef) *string {
	fragmentName := input.RefString()
	return fragmentNameFromString(fragmentName)
}

func fragmentNameFromString(fragmentName string) *string {
	if fragmentName != "" {
		fragments := strings.Split(fragmentName, "/") // format #/definitions/ConfigurationStoreListResult
		referenceName := fragments[len(fragments)-1]

		// url-decode the referenceName, as it comes from the fragment which might contain urlencoded characters like
		// `[` or `]` - ignoring any errors here, since this function will err if invalid escape sequences are present
		referenceName, _ = url.QueryUnescape(referenceName)
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
	keys := make(map[string]struct{})
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

			parsedAsAConstant, constErr := constants.Parse(*topLevelObject.Value.Type, referenceName, nil, topLevelObject.Value.Enum, topLevelObject.Extensions)
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
	typeNames := make(map[string]struct{})

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

func openapi3to2SchemaRef(input *openapi3.SchemaRef) *openapi2.SchemaRef {
	if input.Ref != "" {
		return &openapi2.SchemaRef{
			Ref: input.Ref,
		}
	}

	// 2. Handle Schema Value
	schema3 := input.Value
	if schema3 == nil {
		return &openapi2.SchemaRef{}
	}

	schema2 := openapi2.Schema{}

	if !schema3.Type.Is("") {
		schema2.Type = schema3.Type
	}
	if schema3.Format != "" {
		schema2.Format = schema3.Format
	}
	if schema3.Description != "" {
		schema2.Description = schema3.Description
	}

	// Array Items
	if schema3.Items != nil {
		schema2.Items = openapi3to2SchemaRef(schema3.Items)
	}

	// --- PROPERTIES (Mapping Nested Schemas) ---
	if schema3.Properties != nil && len(schema3.Properties) > 0 {
		props2 := openapi2.Schemas{}
		for name, propRef3 := range schema3.Properties {
			props2[name] = openapi3to2SchemaRef(propRef3)
		}
		schema2.Properties = props2
	}

	// --- ADVANCED FIELD HANDLING (Compromises) ---

	// The 'required' field in OAI3 is a list of strings on the schema itself.
	// In Swagger 2.0, it is also a list of strings on the schema itself.
	schema2.Required = schema3.Required

	// AllOf (Direct mapping is usually safe, as long as the sub-schemas don't use OAI3-only features)
	if len(schema3.AllOf) > 0 {
		log.Println("WARNING: AllOf is being mapped. Ensure nested schemas are OAI2-compatible.")
		allOf := openapi2.SchemaRefs{}
		for i, ref3 := range schema3.AllOf {
			allOf[i] = openapi3to2SchemaRef(ref3)
		}
		schema2.AllOf = allOf
	}

	// AnyOf/OneOf/Not: Cannot be directly represented in Swagger 2.0.
	if len(schema3.AnyOf) > 0 || len(schema3.OneOf) > 0 || schema3.Not != nil {
		log.Printf("ERROR: Detected unsupported OAI3 features (AnyOf/OneOf/Not). Data will be lost/omitted.")
	}

	return &openapi2.SchemaRef{
		Value: &schema2,
	}
}
