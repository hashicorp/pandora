// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"
	"log"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/helpers"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identifyFieldsWithinPropertiesBlock(schemaModelName string, input operationPayloads, resource *resourcemanager.TerraformResourceDetails, mappings *resourcemanager.MappingDefinition, resourceBuildInfo *importerModels.ResourceBuildInfo, named hclog.Logger) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, *resourcemanager.MappingDefinition, error) {
	allFields := make(map[string]struct{}, 0)
	propertiesPayloads := input.createReadUpdatePayloadsProperties()
	for _, model := range propertiesPayloads {
		for k, v := range model.Fields {
			if fieldShouldBeIgnored(k, v, b.constants) {
				continue
			}

			allFields[k] = struct{}{}
		}
	}

	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)
	for k := range allFields {
		// TODO: pull the right models.SDKModel for naming below

		readField, hasRead := getField(input.readPropertiesPayload, k)
		createField, hasCreate := getField(input.createPropertiesPayload, k)

		var updateField *models.SDKField
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

		var validation *resourcemanager.TerraformSchemaValidationDefinition
		var err error
		if hasCreate {
			validation, err = getFieldValidation(*createField, b.constants)
			if err != nil {
				return nil, nil, fmt.Errorf("retrieving validation for field %q: %+v", k, err)
			}
		}

		fieldNameForTypedModel := ""
		if hasRead {
			fieldNameForTypedModel, err = updateFieldName(k, &input.readPropertiesPayload, resource, b.constants, resourceBuildInfo)
		} else if hasCreate {
			fieldNameForTypedModel, err = updateFieldName(k, &input.createPropertiesPayload, resource, b.constants, resourceBuildInfo)
		} else if hasUpdate {
			fieldNameForTypedModel, err = updateFieldName(k, input.updatePropertiesPayload, resource, b.constants, resourceBuildInfo)
		}

		if err != nil {
			return nil, nil, err
		}

		var inputObjectDefinition models.SDKObjectDefinition
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
		definition := resourcemanager.TerraformSchemaFieldDefinition{
			HclName:  schemaFieldName,
			Required: isRequired,
			ForceNew: isForceNew,
			Optional: isOptional,
			Computed: isReadOnlyField,
			// this is only used when outputting the mappings
			// 4 types of mappings: Create/Read/Update/Resource ID - all nullable
			// If a Create and Update Mapping are present but a Read isn't it's implicitly WriteOnly
			//WriteOnly: isWriteOnly,
			Validation: validation,
			Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
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

		if objectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
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

	return &out, mappings, nil
}

func fieldExists(payload models.SDKModel, fieldName string) bool {
	_, ok := payload.Fields[fieldName]
	return ok
}

func directAssignmentMappingForNestedField(schemaModelName, schemaModelField string, input operationPayloads, sdkFieldName string, hasCreate bool, hasUpdate bool, hasRead bool) []resourcemanager.FieldMappingDefinition {
	output := make([]resourcemanager.FieldMappingDefinition, 0)
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
