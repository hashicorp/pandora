package schema

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identifyTopLevelFields(input operationPayloads) (*topLevelFields, error) {
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

			fieldObjectDefinition, err := convertToFieldObjectDefinition(field.ObjectDefinition)
			if err != nil {
				return nil, fmt.Errorf("converting Identity ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
			}
			out.identity = &FieldDefinition{
				Definition: *fieldObjectDefinition,
				Required:   field.Required,
				Optional:   field.Optional,
				ForceNew:   !canBeUpdated,
			}
		}

		if strings.EqualFold(k, "Location") {
			out.location = &FieldDefinition{
				Definition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
				Required: true,
				ForceNew: true,
			}
		}

		if strings.EqualFold(k, "Tags") {
			canBeUpdated := false
			if input.updatePayload != nil {
				if _, ok := getField(*input.updatePayload, k); ok {
					canBeUpdated = true
				}
			}

			out.tags = &FieldDefinition{
				Definition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
				},
				Optional: true,
				ForceNew: !canBeUpdated,
			}
		}
	}

	// TODO: go through any fields _only_ in the Read function which are ReadOnly/Computed

	return &out, nil
}
