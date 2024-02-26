// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"
	"regexp"
	"strings"
	"unicode"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/schema/processors"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func fieldShouldBeIgnored(key string, definition models.SDKField, constants map[string]models.SDKConstant) bool {
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
		if definition.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
			// if it's a reference to a constant, it can be skipped
			if _, ok := constants[*definition.ObjectDefinition.ReferenceName]; ok {
				return true
			}
		}

		// some "State" fields aren't defined as
		if definition.ObjectDefinition.Type == models.StringSDKObjectDefinitionType {
			return true
		}
	}

	return false
}

func getField(model models.SDKModel, fieldName string) (*models.SDKField, bool) {
	for field, val := range model.Fields {
		if strings.EqualFold(field, fieldName) {
			return &val, true
		}
	}

	return nil, false
}

func updateFieldName(fieldName string, model *models.SDKModel, resource *resourcemanager.TerraformResourceDetails, constants map[string]models.SDKConstant, resourceBuildInfo *importerModels.ResourceBuildInfo) (string, error) {
	metadata := processors.FieldMetadata{
		TerraformDetails: *resource,
		Model:            *model,
		Constants:        constants,
	}

	// first we apply the field processing rules for several common renaming scenarios
	for _, matcher := range processors.NamingRules {
		updatedFieldName, err := matcher.ProcessField(fieldName, metadata)
		if err != nil {
			return "", err
		}

		if updatedFieldName != nil {
			return *updatedFieldName, nil
		}
	}

	// if we get this far then we check for any naming overrides that need to happen
	if resourceBuildInfo != nil && resourceBuildInfo.Overrides != nil {
		updatedFieldName, err := applySchemaOverrides(fieldName, resourceBuildInfo.Overrides)
		if err != nil {
			return "", fmt.Errorf("applying schema override for %q: %+v", fieldName, err)
		}

		if updatedFieldName != nil {
			return *updatedFieldName, nil
		}
	}
	return fieldName, nil
}

func applySchemaOverrides(fieldName string, overrides []importerModels.Override) (*string, error) {
	for _, override := range overrides {
		if strings.EqualFold(fieldName, strings.ReplaceAll(override.Name, "_", "")) {
			if override.UpdatedName != nil {
				updated := helpers.ConvertFromSnakeToTitleCase(*override.UpdatedName)
				return &updated, nil
			}
			continue
		}
	}
	return nil, nil
}

func getFieldValidation(input models.SDKField, sdkConstants map[string]models.SDKConstant) (*resourcemanager.TerraformSchemaValidationDefinition, error) {
	// at this time we only support constant values
	if input.ObjectDefinition.Type != models.ReferenceSDKObjectDefinitionType {
		return nil, nil
	}
	constant, ok := sdkConstants[*input.ObjectDefinition.ReferenceName]
	if !ok {
		// could be a model
		return nil, nil
	}

	vals := make([]interface{}, 0)
	for _, val := range constant.Values {
		vals = append(vals, val)
	}

	constantTypesToPossibleValueTypes := map[models.SDKConstantType]resourcemanager.TerraformSchemaValidationPossibleValueType{
		models.FloatSDKConstantType:   resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat,
		models.IntegerSDKConstantType: resourcemanager.TerraformSchemaValidationPossibleValueTypeInt,
		models.StringSDKConstantType:  resourcemanager.TerraformSchemaValidationPossibleValueTypeString,
	}
	possibleValueType, ok := constantTypesToPossibleValueTypes[constant.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: unimplemented constant type %q", string(constant.Type))
	}

	return &resourcemanager.TerraformSchemaValidationDefinition{
		Type: resourcemanager.TerraformSchemaValidationTypePossibleValues,
		PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
			Type:   possibleValueType,
			Values: vals,
		},
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
