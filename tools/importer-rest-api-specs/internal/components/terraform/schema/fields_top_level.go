// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (b Builder) schemaFromTopLevelFields(schemaModelName string, input operationPayloads, mappings *sdkModels.TerraformMappingDefinition, resourceDisplayName string) (map[string]sdkModels.TerraformSchemaField, *sdkModels.TerraformMappingDefinition, error) {
	allFields := make(map[string]struct{})
	for _, model := range input.createReadUpdatePayloads() {
		for k := range model.Fields {
			allFields[k] = struct{}{}
		}
	}

	schemaFields := make(map[string]sdkModels.TerraformSchemaField)
	for fieldName := range allFields {
		hasCreate := false
		if _, ok := getField(input.createPayload, fieldName); ok {
			hasCreate = true
		}

		hasUpdate := false
		if input.updatePayload != nil {
			if _, ok := getField(*input.updatePayload, fieldName); ok {
				hasUpdate = true
			}
		}
		hasRead := false
		if _, ok := getField(input.readPropertiesPayload, fieldName); ok {
			hasRead = true
		}

		// TODO: ExtendedLocation, SystemData as Computed etc?
		if strings.EqualFold(fieldName, "Identity") {
			field, ok := getField(input.createPayload, fieldName)
			if !ok {
				continue
			}

			fieldObjectDefinition, err := b.convertToFieldObjectDefinition(schemaModelName, field.ObjectDefinition)
			if err != nil {
				return nil, nil, fmt.Errorf("converting Identity ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
			}

			schemaFields["Identity"] = sdkModels.TerraformSchemaField{
				ObjectDefinition: *fieldObjectDefinition,
				Required:         field.Required,
				Optional:         field.Optional,
				ForceNew:         !hasUpdate,
				HCLName:          "identity",
				Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
					Markdown: fmt.Sprintf("Specifies the Managed Identity which should be assigned to this %s.", resourceDisplayName),
				},
			}

			mappingsForField := directAssignmentMappingForTopLevelField(schemaModelName, "Identity", input, fieldName, hasCreate, hasUpdate, hasRead)
			mappings.Fields = append(mappings.Fields, mappingsForField...)
		}

		if strings.EqualFold(fieldName, "Location") {
			schemaFields["Location"] = sdkModels.TerraformSchemaField{
				HCLName: "location",
				ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
					Type: sdkModels.LocationTerraformSchemaObjectDefinitionType,
				},
				Required: true,
				ForceNew: true,
				Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
					Markdown: fmt.Sprintf("The Azure Region where the %s should exist.", resourceDisplayName),
				},
			}

			mappingsForField := directAssignmentMappingForTopLevelField(schemaModelName, "Location", input, fieldName, hasCreate, false, hasRead)
			mappings.Fields = append(mappings.Fields, mappingsForField...)
		}

		if strings.EqualFold(fieldName, "Tags") {
			canBeUpdated := false
			if input.updatePayload != nil {
				if _, ok := getField(*input.updatePayload, fieldName); ok {
					canBeUpdated = true
				}
			}

			schemaFields["Tags"] = sdkModels.TerraformSchemaField{
				HCLName: "tags",
				ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
					Type: sdkModels.TagsTerraformSchemaObjectDefinitionType,
				},
				Optional: true,
				ForceNew: !canBeUpdated,
				Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
					Markdown: fmt.Sprintf("A mapping of tags which should be assigned to the %s.", resourceDisplayName),
				},
			}

			mappingsForField := directAssignmentMappingForTopLevelField(schemaModelName, "Tags", input, fieldName, hasCreate, hasUpdate, hasRead)
			mappings.Fields = append(mappings.Fields, mappingsForField...)
		}

		if strings.EqualFold(fieldName, "Sku") {
			field, ok := getField(input.createPayload, fieldName)
			if !ok {
				continue
			}

			fieldObjectDefinition, err := b.convertToFieldObjectDefinition(schemaModelName, field.ObjectDefinition)
			if err != nil {
				return nil, nil, fmt.Errorf("converting Sku ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
			}

			schemaFields["Sku"] = sdkModels.TerraformSchemaField{
				ObjectDefinition: *fieldObjectDefinition,
				Required:         field.Required,
				Optional:         field.Optional,
				ForceNew:         !hasUpdate,
				HCLName:          "sku",
				Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
					Markdown: field.Description,
				},
			}

			mappingsForField := directAssignmentMappingForTopLevelField(schemaModelName, "Sku", input, fieldName, hasCreate, hasUpdate, hasRead)
			mappings.Fields = append(mappings.Fields, mappingsForField...)
		}

		if strings.EqualFold(fieldName, "Zone") {
			field, ok := getField(input.createPayload, fieldName)
			if !ok {
				continue
			}

			schemaFields["Zone"] = sdkModels.TerraformSchemaField{
				ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
					Type: sdkModels.ZoneTerraformSchemaObjectDefinitionType,
				},
				Required: field.Required,
				Optional: field.Optional,
				ForceNew: !hasUpdate,
				HCLName:  "zone",
				Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
					Markdown: field.Description,
				},
			}

			mappingsForField := directAssignmentMappingForTopLevelField(schemaModelName, "Zone", input, fieldName, hasCreate, hasUpdate, hasRead)
			mappings.Fields = append(mappings.Fields, mappingsForField...)
		}

		if strings.EqualFold(fieldName, "Zones") {
			field, ok := getField(input.createPayload, fieldName)
			if !ok {
				continue
			}

			schemaFields["Zones"] = sdkModels.TerraformSchemaField{
				ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
					Type: sdkModels.ZonesTerraformSchemaObjectDefinitionType,
				},
				Required: field.Required,
				Optional: field.Optional,
				ForceNew: !hasUpdate,
				HCLName:  "zones",
				Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
					Markdown: field.Description,
				},
			}

			mappingsForField := directAssignmentMappingForTopLevelField(schemaModelName, "Zones", input, fieldName, hasCreate, hasUpdate, hasRead)
			mappings.Fields = append(mappings.Fields, mappingsForField...)
		}
	}

	// TODO: go through any fields _only_ in the Read function which are ReadOnly/Computed

	return schemaFields, mappings, nil
}

func directAssignmentMappingForTopLevelField(schemaModelName, schemaModelField string, input operationPayloads, sdkFieldName string, hasCreate bool, hasUpdate bool, hasRead bool) []sdkModels.TerraformFieldMappingDefinition {
	output := make([]sdkModels.TerraformFieldMappingDefinition, 0)
	if hasCreate {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, input.createModelName, sdkFieldName))
	}
	if hasRead && input.createModelName != input.readModelName {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, input.readModelName, sdkFieldName))
	}
	if hasUpdate && input.updateModelName != nil && input.createModelName != *input.updateModelName && input.readModelName != *input.updateModelName {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, *input.updateModelName, sdkFieldName))
	}
	return output
}
