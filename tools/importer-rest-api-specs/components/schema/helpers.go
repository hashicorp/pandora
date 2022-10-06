package schema

import (
	"fmt"
	"regexp"
	"strings"
	"unicode"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/schema/processors"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func fieldShouldBeIgnored(key string, definition resourcemanager.FieldDetails, constants map[string]resourcemanager.ConstantDetails) bool {
	for _, v := range fieldsWhichShouldBeIgnoredExactMatch {
		if strings.EqualFold(key, v) {
			return true
		}
	}

	lowered := strings.ToLower(key)
	for _, v := range fieldsWhichShouldBeIgnoredIfContains {
		if strings.Contains(lowered, strings.ToLower(v)) {
			return true
		}
	}

	// due to differences in the source data, we need to handle both the field being a constant and a string value
	if strings.Contains(lowered, "state") || strings.Contains(lowered, "status") {
		if definition.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			// if it's a reference to a constant, it can be skipped
			if _, ok := constants[*definition.ObjectDefinition.ReferenceName]; ok {
				return true
			}
		}

		// some "State" fields aren't defined as
		if definition.ObjectDefinition.Type == resourcemanager.StringApiObjectDefinitionType {
			return true
		}
	}

	return false
}

func getField(model resourcemanager.ModelDetails, fieldName string) (*resourcemanager.FieldDetails, bool) {
	for field, val := range model.Fields {
		if strings.EqualFold(field, fieldName) {
			return &val, true
		}
	}

	return nil, false
}

func updateFieldName(fieldName string, model *resourcemanager.ModelDetails, resource *resourcemanager.TerraformResourceDetails) (string, error) {
	metadata := processors.FieldMetadata{
		TerraformDetails: *resource,
		Model:            *model,
	}
	for _, matcher := range processors.NamingRules {
		updatedFieldName, err := matcher.ProcessField(fieldName, metadata)
		if err != nil {
			return "", err
		}

		if updatedFieldName != nil {
			return *updatedFieldName, nil
		}
	}
	return fieldName, nil
}

func stringPointer(input string) *string {
	return &input
}

func getFieldValidation(input *resourcemanager.FieldValidationDetails, fieldName string) (*resourcemanager.TerraformSchemaValidationDefinition, error) {
	if input == nil {
		return nil, nil
	}
	var validationType resourcemanager.TerraformSchemaValidationType
	var possibleValues *resourcemanager.TerraformSchemaValidationPossibleValuesDefinition
	switch input.Type {
	case resourcemanager.RangeValidation:
		validationType = resourcemanager.TerraformSchemaValidationTypePossibleValues
		if values := input.Values; values == nil || len(*values) == 0 {
			return nil, fmt.Errorf("field %q had Range Validation type but had no defined values", fieldName)
		} else {
			t := (*values)[0]
			switch t.(type) {
			case string:
				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeString,
					Values: *values,
				}
				break

			case int64:
				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeInt,
					Values: *values,
				}
				break

			case float64:
				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat,
					Values: *values,
				}
				break
			}
		}
	}

	return &resourcemanager.TerraformSchemaValidationDefinition{
		Type:           validationType,
		PossibleValues: possibleValues,
	}, nil
}

func directAssignmentMappingBetween(fromModel string, fromField string, toModel string, toField string) resourcemanager.FieldMappingDefinition {
	return resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.DirectAssignmentMappingDefinitionType,
		DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
			SchemaModelName: fromModel,
			SchemaFieldPath: fromField,
			SdkModelName:    toModel,
			SdkFieldPath:    toField,
		},
	}
}

func modelToModelMappingBetween(fromModel string, toModel string, toField string) resourcemanager.FieldMappingDefinition {
	return resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ModelToModelMappingDefinitionType,
		ModelToModel: &resourcemanager.FieldMappingModelToModelDefinition{
			SchemaModelName: fromModel,
			SdkModelName:    toModel,
			SdkFieldName:    toField,
		},
	}
}

func extractDescription(markdown string) string {
	if markdown == "" {
		return ""
	}

	// extract first sentence in markdown
	re := regexp.MustCompile(`(^.*?([.?!]|$))(?:\s|$)`)
	description := re.FindString(markdown)

	// cut examples and minimum api versions
	description, _, _ = strings.Cut(description, "Minimum api-version:")
	description, _, _ = strings.Cut(description, "; example")

	// recase words as required
	description = strings.ReplaceAll(description, "identity", "Identity")
	description = strings.ReplaceAll(description, "id", "ID")
	description = strings.ReplaceAll(description, "principal", "Principal")
	description = strings.ReplaceAll(description, "service", "Service")
	description = strings.ReplaceAll(description, "tenant", "Tenant")

	if description != "" {
		description = capitalizeFirstLetter(description)

		// check end of sentence punctuation
		re = regexp.MustCompile(`(^.*[.?!]\s?$)`)
		if !re.MatchString(description) {
			description = punctuateEndOfSentence(description)
		}
	}
	description = strings.TrimSpace(description)

	return description
}

func capitalizeFirstLetter(s string) string {
	r := []rune(s)
	r[0] = unicode.ToUpper(r[0])
	return string(r)
}

func punctuateEndOfSentence(s string) string {
	s = strings.TrimSpace(s)
	if strings.HasSuffix(s, ",") || strings.HasSuffix(s, ":") || strings.HasSuffix(s, ";") {
		s = s[:len(s)-1]
	}
	return fmt.Sprintf("%s.", s)
}
