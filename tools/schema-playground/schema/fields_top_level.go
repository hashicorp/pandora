package schema

import (
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

			out.identity = &FieldDefinition{
				Definition: resourcemanager.ApiObjectDefinition{
					Type: field.ObjectDefinition.Type,
				},
				Required: field.Required,
				Optional: field.Optional,
				ForceNew: !canBeUpdated,
			}
		}

		if strings.EqualFold(k, "Location") {
			out.location = &FieldDefinition{
				Definition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.LocationApiObjectDefinitionType,
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
				Definition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.TagsApiObjectDefinitionType,
				},
				Optional: true,
				ForceNew: !canBeUpdated,
			}
		}
	}

	// TODO: go through any fields _only_ in the Read function which are ReadOnly/Computed

	return &out, nil
}
