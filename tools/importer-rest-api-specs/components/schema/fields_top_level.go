package schema

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) schemaFromTopLevelFields(schemaModelName string, input operationPayloads, mappings *resourcemanager.MappingDefinition, resourceDisplayName string, named hclog.Logger) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, *resourcemanager.MappingDefinition, error) {
	allFields := make(map[string]struct{}, 0)
	for _, model := range input.createReadUpdatePayloads() {
		for k := range model.Fields {
			allFields[k] = struct{}{}
		}
	}

	schemaFields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
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

			schemaFields["Identity"] = resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: *fieldObjectDefinition,
				Required:         field.Required,
				Optional:         field.Optional,
				ForceNew:         !hasUpdate,
				HclName:          "identity",
				Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
					Markdown: field.Description,
				},
			}

			mappingsForField := directAssignmentMappingForTopLevelField(schemaModelName, "Identity", input, fieldName, hasCreate, hasUpdate, hasRead)
			mappings.Fields = append(mappings.Fields, mappingsForField...)
		}

		if strings.EqualFold(fieldName, "Location") {
			schemaFields["Location"] = resourcemanager.TerraformSchemaFieldDefinition{
				HclName: "location",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
				Required: true,
				ForceNew: true,
				Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
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

			schemaFields["Tags"] = resourcemanager.TerraformSchemaFieldDefinition{
				HclName: "tags",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
				},
				Optional: true,
				ForceNew: !canBeUpdated,
				Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
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

			schemaFields["Sku"] = resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: *fieldObjectDefinition,
				Required:         field.Required,
				Optional:         field.Optional,
				ForceNew:         !hasUpdate,
				HclName:          "sku",
				Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
					Markdown: field.Description,
				},
			}

			mappingsForField := directAssignmentMappingForTopLevelField(schemaModelName, "Sku", input, fieldName, hasCreate, hasUpdate, hasRead)
			mappings.Fields = append(mappings.Fields, mappingsForField...)
		}
	}

	// TODO: go through any fields _only_ in the Read function which are ReadOnly/Computed

	return &schemaFields, mappings, nil
}

func directAssignmentMappingForTopLevelField(schemaModelName, schemaModelField string, input operationPayloads, sdkFieldName string, hasCreate bool, hasUpdate bool, hasRead bool) []resourcemanager.FieldMappingDefinition {
	output := make([]resourcemanager.FieldMappingDefinition, 0)
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
