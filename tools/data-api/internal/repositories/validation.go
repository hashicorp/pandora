package repositories

import "fmt"

func validateModels(input map[string]ModelDetails, constants map[string]ConstantDetails) error {
	for modelName, modelDetail := range input {
		for _, field := range modelDetail.Fields {
			if err := validateObjectDefinition(field.ObjectDefinition, constants, input); err != nil {
				return fmt.Errorf("validating model %q: %+v", modelName, err)
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
