// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repositories

import (
	"fmt"
)

func validateModels(input map[string]ModelDetails, constants map[string]ConstantDetails) error {
	for modelName, modelDetail := range input {
		if modelDetail.ParentTypeName != nil || modelDetail.TypeHintValue != nil {
			if modelDetail.ParentTypeName == nil {
				return fmt.Errorf("model %q: model implements a discriminated type but `ParentTypeName` is unset", modelName)
			}
			if modelDetail.TypeHintValue == nil {
				return fmt.Errorf("model %q: model implements a discriminated type but `TypeHintValue` is unset", modelName)
			}
			if modelDetail.TypeHintIn == nil {
				return fmt.Errorf("model %q: model implements a discriminated type but `TypeHintIn` is unset", modelName)
			}

			parentModel, ok := input[*modelDetail.ParentTypeName]
			if !ok {
				return fmt.Errorf("model %q: discriminated parent type model %q not found", modelName, *modelDetail.ParentTypeName)
			}

			typeHintIn := ""
			for fieldName, fieldDetail := range parentModel.Fields {
				if fieldDetail.IsTypeHint {
					if typeHintIn != "" {
						return fmt.Errorf("model %q: a `TypeHintIn` already exists for this model, existing: %s duplicate: %s", modelName, typeHintIn, fieldName)
					}
					typeHintIn = fieldName
					continue
				}
			}

		}
		for fieldName, field := range modelDetail.Fields {
			if field.IsTypeHint {
				if modelDetail.TypeHintIn == nil {
					return fmt.Errorf("model %q: field provides type hint but model is missing `TypeHintIn` information", modelName)
				}
				if *modelDetail.TypeHintIn != fieldName {
					return fmt.Errorf("model %q: field provides type hint but `TypeHintIn` is set to %s, should be %s", modelName, *modelDetail.TypeHintIn, fieldName)
				}
			}
			if err := validateObjectDefinition(field.ObjectDefinition, constants, input); err != nil {
				return fmt.Errorf("model %q: %+v", modelName, err)
			}
		}
	}
	return nil
}

func validateOperations(input map[string]ResourceOperations, apiModels map[string]ModelDetails, constants map[string]ConstantDetails) error {
	for operationName, operationDetail := range input {
		if operationDetail.RequestObject != nil {
			if err := validateObjectDefinition(*operationDetail.RequestObject, constants, apiModels); err != nil {
				return fmt.Errorf("operation request object %q: %+v", operationName, err)
			}
		}
		if operationDetail.ResponseObject != nil {
			if err := validateObjectDefinition(*operationDetail.ResponseObject, constants, apiModels); err != nil {
				return fmt.Errorf("operation response object %q: %+v", operationName, err)
			}
		}
	}
	return nil
}

func validateObjectDefinition(input ObjectDefinition, constants map[string]ConstantDetails, models map[string]ModelDetails) error {
	requiresNestedItem := input.Type == CsvObjectDefinitionType ||
		input.Type == DictionaryObjectDefinitionType ||
		input.Type == ListObjectDefinitionType
	requiresReference := input.Type == ReferenceObjectDefinitionType

	if input.NestedItem != nil {
		if !requiresNestedItem {
			return fmt.Errorf("a Nested Object Definition must not be specified for a %q type but got %q", string(input.Type), string(input.NestedItem.Type))
		}
		if err := validateObjectDefinition(*input.NestedItem, constants, models); err != nil {
			return fmt.Errorf("validating Nested Object Definition: %+v", err)
		}
	}

	if requiresNestedItem && input.NestedItem == nil {
		return fmt.Errorf("a Nested Object Definition must be specified for a %q type but didn't get one", string(input.Type))
	}

	if requiresReference {
		if input.ReferenceName == nil {
			return fmt.Errorf("a Reference must be specified for a %q type but didn't get one", string(input.Type))
		}

		_, isConstant := constants[*input.ReferenceName]
		_, isModel := models[*input.ReferenceName]
		if !isConstant && !isModel {
			return fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
		}
		if isConstant && isModel {
			return fmt.Errorf("internal-error: %q was found as BOTH a Constant and a Model", *input.ReferenceName)
		}
	}
	if !requiresReference && input.ReferenceName != nil {
		return fmt.Errorf("a Reference must not be specified for a %q type but got %q", string(input.Type), *input.ReferenceName)
	}

	return nil
}

func validateOptionObjectDefinition(input OptionObjectDefinition, constants map[string]ConstantDetails, apiModels map[string]ModelDetails) error {
	requiresNestedItem := input.Type == CsvOptionObjectDefinitionType || input.Type == ListOptionObjectDefinitionType
	requiresReference := input.Type == ReferenceOptionObjectDefinitionType
	if requiresNestedItem && input.NestedItem == nil {
		return fmt.Errorf("a Nested Object Definition must be specified for a %q type but didn't get one", string(input.Type))
	}
	if !requiresNestedItem && input.NestedItem != nil {
		return fmt.Errorf("a Nested Object Definition must not be specified for a %q type but got %q", string(input.Type), string(input.NestedItem.Type))
	}
	if requiresReference {
		if input.ReferenceName == nil {
			return fmt.Errorf("a Reference must be specified for a %q type but didn't get one", string(input.Type))
		}

		_, isConstant := constants[*input.ReferenceName]
		_, isModel := apiModels[*input.ReferenceName]
		if !isConstant && !isModel {
			return fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
		}
		if isConstant && isModel {
			return fmt.Errorf("internal-error: %q was found as BOTH a Constant and a Model", *input.ReferenceName)
		}
	}
	if !requiresReference && input.ReferenceName != nil {
		return fmt.Errorf("a Reference must not be specified for a %q type but got %q", string(input.Type), *input.ReferenceName)
	}

	return nil
}
