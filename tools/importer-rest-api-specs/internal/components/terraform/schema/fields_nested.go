// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"
	"log"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/schema/helpers"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func (b Builder) identifyFieldsWithinPropertiesBlock(schemaModelName string, input operationPayloads, resource *sdkModels.TerraformResourceDefinition, mappings *sdkModels.TerraformMappingDefinition, resourceDefinition definitions.ResourceDefinition) (map[string]sdkModels.TerraformSchemaField, *sdkModels.TerraformMappingDefinition, error) {
	allFields := make(map[string]struct{}, 0)
	propertiesPayloads := input.createReadUpdatePayloadsProperties()
	for _, model := range propertiesPayloads {
		for k, v := range model.Fields {
			if fieldShouldBeIgnored(k, v, b.apiResource.Constants) {
				continue
			}

			allFields[k] = struct{}{}
		}
	}

	out := make(map[string]sdkModels.TerraformSchemaField, 0)
	for k := range allFields {
		// TODO: pull the right models.SDKModel for naming below

		readField, hasRead := getField(input.readPropertiesPayload, k)
		createField, hasCreate := getField(input.createPropertiesPayload, k)

		var updateField *sdkModels.SDKField
		hasUpdate := false
		if input.updatePropertiesPayload != nil {
			// we can assume ID fields are not updatable even if they're in the CreateUpdate payload
			// we ignore some fields temporarily until we can extend the functionality for update tests
			if !strings.HasSuffix(k, "Id") && !ignoreUpdateForField(k) {
				updateField, hasUpdate = getField(*input.updatePropertiesPayload, k)
			}
		}

		// based on this information
		isReadOnlyField := (hasCreate && createField.ReadOnly) || (hasRead && readField.ReadOnly)
		isForceNew := false
		isRequired := false
		isOptional := false

		if !hasCreate && !hasUpdate && hasRead {
			isReadOnlyField = true
		}
		if hasCreate || hasUpdate {
			if hasCreate {
				isRequired = createField.Required
				isOptional = createField.Optional
				isForceNew = !hasUpdate
			} else if hasUpdate {
				isRequired = updateField.Required
				isOptional = updateField.Optional
			}
		}
		if isReadOnlyField {
			isRequired = false
			isOptional = false
			isForceNew = false
		}

		if isRequired && isOptional {
			return nil, nil, fmt.Errorf("internal-error: the Field %q was both Required and Optional", k)
		}

		var validation sdkModels.TerraformSchemaFieldValidationDefinition
		var err error
		if hasCreate {
			validation, err = getFieldValidation(*createField, b.apiResource.Constants)
			if err != nil {
				return nil, nil, fmt.Errorf("retrieving validation for field %q: %+v", k, err)
			}
		}

		fieldNameForTypedModel := ""
		if hasRead {
			fieldNameForTypedModel, err = updateFieldName(k, &input.readPropertiesPayload, resource, b.apiResource.Constants, resourceDefinition)
		} else if hasCreate {
			fieldNameForTypedModel, err = updateFieldName(k, &input.createPropertiesPayload, resource, b.apiResource.Constants, resourceDefinition)
		} else if hasUpdate {
			fieldNameForTypedModel, err = updateFieldName(k, input.updatePropertiesPayload, resource, b.apiResource.Constants, resourceDefinition)
		}

		if err != nil {
			return nil, nil, err
		}

		var inputObjectDefinition sdkModels.SDKObjectDefinition
		if hasRead {
			inputObjectDefinition = readField.ObjectDefinition
		} else if hasCreate {
			inputObjectDefinition = createField.ObjectDefinition
		} else if hasUpdate {
			inputObjectDefinition = updateField.ObjectDefinition
		}

		schemaFieldName := helpers.ConvertToSnakeCase(fieldNameForTypedModel)
		log.Printf("[DEBUG] Properties Field %q would be output as %q / %q", k, fieldNameForTypedModel, schemaFieldName)

		if !isOptional && !isRequired {
			isReadOnlyField = true
			isForceNew = false
		}

		// TODO(@tombuildsstuff): refactor this and the "nested model" field to use the same parser ideally..?!
		definition := sdkModels.TerraformSchemaField{
			HCLName:  schemaFieldName,
			Required: isRequired,
			ForceNew: isForceNew,
			Optional: isOptional,
			Computed: isReadOnlyField,
			// this is only used when outputting the mappings
			// 4 types of mappings: Create/Read/Update/Resource ID - all nullable
			// If a Create and Update Mapping are present but a Read isn't it's implicitly WriteOnly
			//WriteOnly: isWriteOnly,
			Validation: validation,
			Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
				Markdown: "TODO",
			},
		}
		if hasCreate {
			definition.Documentation.Markdown = extractDescription(createField.Description)
		} else if hasUpdate {
			definition.Documentation.Markdown = extractDescription(updateField.Description)
		} else if hasRead {
			definition.Documentation.Markdown = extractDescription(readField.Description)
		}

		objectDefinition, err := b.convertToFieldObjectDefinition(schemaModelName, inputObjectDefinition)
		if err != nil {
			return nil, nil, fmt.Errorf("converting ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
		}
		definition.ObjectDefinition = *objectDefinition

		if objectDefinition.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
			nestedModelName := *objectDefinition.ReferenceName
			if fieldExists(input.createPropertiesPayload, k) {
				mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(nestedModelName, input.createPropertiesModelName, k))
			}

			if fieldExists(input.readPropertiesPayload, k) && input.createPropertiesModelName != input.readPropertiesModelName {
				mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(nestedModelName, input.readPropertiesModelName, k))
			}
			if input.updatePayload != nil && input.updatePropertiesPayload != nil && fieldExists(*input.updatePropertiesPayload, k) {
				if input.createPropertiesModelName != *input.updatePropertiesModelName && input.readPropertiesModelName != *input.updatePropertiesModelName {
					mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(nestedModelName, *input.updatePropertiesModelName, k))
				}
			}
		}

		mappingsForField := directAssignmentMappingForNestedField(schemaModelName, fieldNameForTypedModel, input, k, hasCreate, hasUpdate, hasRead)
		mappings.Fields = append(mappings.Fields, mappingsForField...)
		out[fieldNameForTypedModel] = definition
	}

	// output a ModelToModel mapping between the top-level Properties field for each of the payloads and their associated models
	// so that we can map inlined fields
	fieldName := "Properties"
	if fieldExists(input.createPayload, fieldName) {
		mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(schemaModelName, input.createModelName, fieldName))
	}
	if fieldExists(input.readPayload, fieldName) && input.createModelName != input.readModelName {
		mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(schemaModelName, input.readModelName, fieldName))
	}
	if input.updatePayload != nil && fieldExists(*input.updatePayload, fieldName) {
		if input.updatePayload != nil && input.createModelName != *input.updateModelName && input.readModelName != *input.updateModelName {
			mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(schemaModelName, *input.updateModelName, fieldName))
		}
	}

	return out, mappings, nil
}

func fieldExists(payload sdkModels.SDKModel, fieldName string) bool {
	_, ok := payload.Fields[fieldName]
	return ok
}

func directAssignmentMappingForNestedField(schemaModelName, schemaModelField string, input operationPayloads, sdkFieldName string, hasCreate bool, hasUpdate bool, hasRead bool) []sdkModels.TerraformFieldMappingDefinition {
	output := make([]sdkModels.TerraformFieldMappingDefinition, 0)
	if hasCreate {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, input.createPropertiesModelName, sdkFieldName))
	}
	if hasRead && input.createPropertiesModelName != input.readPropertiesModelName {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, input.readPropertiesModelName, sdkFieldName))
	}
	if hasUpdate && input.updatePropertiesModelName != nil && input.createPropertiesModelName != *input.updatePropertiesModelName && input.readPropertiesModelName != *input.updatePropertiesModelName {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, *input.updatePropertiesModelName, sdkFieldName))
	}
	return output
}

// TODO this is a temporary check to keep the currently generated resources unchanged this can be removed
// when functionality for update tests are extended
func ignoreUpdateForField(field string) bool {
	fieldsToIgnoreInUpdate := []string{
		"HubProfile",
		"Description",
	}
	for _, f := range fieldsToIgnoreInUpdate {
		if strings.EqualFold(field, f) {
			return true
		}
	}
	return false
}
