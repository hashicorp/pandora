package schema

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identifyTopLevelFields(modelNamePrefix string, input operationPayloads) (*topLevelFields, error) {
	allFields := make(map[string]struct{}, 0)
	for _, model := range input.createReadUpdatePayloads() {
		for k := range model.Fields {
			allFields[k] = struct{}{}
		}
	}

	out := topLevelFields{}
	for k := range allFields {
		// TODO: ExtendedLocation, SystemData as Computed etc?
		if strings.EqualFold(k, "Identity") {
			field, ok := getField(input.createPayload, k)
			if !ok {
				continue
			}

			canBeUpdated := false
			if input.updatePayload != nil {
				if _, ok := getField(*input.updatePayload, k); ok {
					canBeUpdated = true
				}
			}

			fieldObjectDefinition, err := b.convertToFieldObjectDefinition(modelNamePrefix, field.ObjectDefinition)
			if err != nil {
				return nil, fmt.Errorf("converting Identity ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
			}
			out.identity = &resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: *fieldObjectDefinition,
				Required:         field.Required,
				Optional:         field.Optional,
				ForceNew:         !canBeUpdated,
				HclName:          "identity",
				Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
					Markdown: field.Description,
				},
			}
		}

		if strings.EqualFold(k, "Location") {
			out.location = &resourcemanager.TerraformSchemaFieldDefinition{
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
		}

		if strings.EqualFold(k, "Tags") {
			canBeUpdated := false
			if input.updatePayload != nil {
				if _, ok := getField(*input.updatePayload, k); ok {
					canBeUpdated = true
				}
			}

			out.tags = &resourcemanager.TerraformSchemaFieldDefinition{
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
		}

		if strings.EqualFold(k, "Sku") {
			field, ok := getField(input.createPayload, k)
			if !ok {
				continue
			}

			canBeUpdated := false
			if input.updatePayload != nil {
				if _, ok := getField(*input.updatePayload, k); ok {
					canBeUpdated = true
				}
			}

			fieldObjectDefinition, err := b.convertToFieldObjectDefinition(modelNamePrefix, field.ObjectDefinition)
			if err != nil {
				return nil, fmt.Errorf("converting Sku ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
			}

			out.sku = &resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: *fieldObjectDefinition,
				Required:         field.Required,
				Optional:         field.Optional,
				ForceNew:         !canBeUpdated,
				HclName:          "sku",
				Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
					Markdown: field.Description,
				},
			}
		}
	}

	// TODO: go through any fields _only_ in the Read function which are ReadOnly/Computed

	return &out, nil
}
