package schema

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type operationPayloads struct {
	createPayload resourcemanager.ModelDetails
	readPayload   resourcemanager.ModelDetails
	updatePayload *resourcemanager.ModelDetails
}

func (p operationPayloads) createReadUpdatePayloads() []resourcemanager.ModelDetails {
	out := []resourcemanager.ModelDetails{
		p.createPayload,
		p.readPayload,
	}
	if p.updatePayload != nil {
		out = append(out, *p.updatePayload)
	}
	return out
}

func (p operationPayloads) createReadUpdatePayloadsProperties(models map[string]resourcemanager.ModelDetails) []resourcemanager.ModelDetails {
	out := make([]resourcemanager.ModelDetails, 0)

	for _, payload := range p.createReadUpdatePayloads() {
		if props := p.getPropertiesModelWithinModel(payload, models); props != nil {
			out = append(out, *props)
		}
	}

	return out
}

func (p operationPayloads) getPropertiesModelWithinModel(input resourcemanager.ModelDetails, models map[string]resourcemanager.ModelDetails) *resourcemanager.ModelDetails {
	if props, ok := getField(input, "Properties"); ok {
		if props.ObjectDefinition.Type != resourcemanager.ReferenceApiObjectDefinitionType {
			return nil
		}

		model, ok := models[*props.ObjectDefinition.ReferenceName]
		if !ok {
			return nil
		}

		return &model
	}

	return nil
}

type topLevelFields struct {
	location *resourcemanager.TerraformSchemaFieldDefinition
	identity *resourcemanager.TerraformSchemaFieldDefinition
	tags     *resourcemanager.TerraformSchemaFieldDefinition
	sku      *resourcemanager.TerraformSchemaFieldDefinition

	/*
		TODO:
		* ExtendedLocation
		* SystemData (computed)
	*/
}

func (f topLevelFields) toSchema() map[string]resourcemanager.TerraformSchemaFieldDefinition {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)

	if f.location != nil {
		out["Location"] = *f.location
	}

	if f.identity != nil {
		out["Identity"] = *f.identity
	}

	if f.tags != nil {
		out["Tags"] = *f.tags
	}

	if f.sku != nil {
		out["Sku"] = *f.sku
	}

	return out
}
