package schema

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) schemaFromTopLevelFields(schemaModelName string, input operationPayloads, mappings *resourcemanager.MappingDefinition, named hclog.Logger) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, *resourcemanager.MappingDefinition, error) {
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
		if _, ok := getField(input.createPayload, fieldName); ok {
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
			if hasCreate {
				mappings.Create = append(mappings.Create, directAssignmentMappingBetween(schemaModelName, "Identity", input.createModelName, fieldName))
			}
			if hasRead {
				mappings.Read = append(mappings.Read, directAssignmentMappingBetween(schemaModelName, "Identity", input.readModelName, fieldName))
			}
			if hasUpdate {
				out := append(*mappings.Update, directAssignmentMappingBetween(schemaModelName, "Identity", *input.updateModelName, fieldName))
				mappings.Update = &out
			}
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
					Markdown: fmt.Sprintf("The Azure Region where the resource should exist."), // TODO get resource name here?
				},
			}
			if hasCreate {
				mappings.Create = append(mappings.Create, directAssignmentMappingBetween(schemaModelName, "Location", input.createModelName, fieldName))
			}
			if hasRead {
				mappings.Read = append(mappings.Read, directAssignmentMappingBetween(schemaModelName, "Location", input.readModelName, fieldName))
			}
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
					Markdown: fmt.Sprintf("A mapping of tags which should be assigned to the Resource."), // TODO get resource name here?
				},
			}
			if hasCreate {
				mappings.Create = append(mappings.Create, directAssignmentMappingBetween(schemaModelName, "Tags", input.createModelName, fieldName))
			}
			if hasUpdate {
				out := append(*mappings.Update, directAssignmentMappingBetween(schemaModelName, "Tags", *input.updateModelName, fieldName))
				mappings.Update = &out
			}
			if hasRead {
				mappings.Read = append(mappings.Read, directAssignmentMappingBetween(schemaModelName, "Tags", input.readModelName, fieldName))
			}
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

			if hasCreate {
				mappings.Create = append(mappings.Create, directAssignmentMappingBetween(schemaModelName, "Sku", input.createModelName, fieldName))
			}
			if hasUpdate {
				out := append(*mappings.Update, directAssignmentMappingBetween(schemaModelName, "Sku", *input.updateModelName, fieldName))
				mappings.Update = &out
			}
			if hasRead {
				mappings.Read = append(mappings.Read, directAssignmentMappingBetween(schemaModelName, "Sku", input.readModelName, fieldName))
			}
		}
	}

	// TODO: go through any fields _only_ in the Read function which are ReadOnly/Computed

	return &schemaFields, mappings, nil
}

func directAssignmentMappingBetween(fromModel string, fromField string, toModel string, toField string) resourcemanager.FieldMappingDefinition {
	return resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.DirectAssignmentMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: fromModel,
			SchemaFieldPath: fromField,
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkModelName: toModel,
			SdkFieldPath: toField,
		},
	}
}
