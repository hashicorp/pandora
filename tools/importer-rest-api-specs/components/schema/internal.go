package schema

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type operationPayloads struct {
	createModelName           string
	createPayload             resourcemanager.ModelDetails
	createPropertiesModelName string
	createPropertiesPayload   resourcemanager.ModelDetails

	readModelName           string
	readPayload             resourcemanager.ModelDetails
	readPropertiesModelName string
	readPropertiesPayload   resourcemanager.ModelDetails

	updateModelName           *string
	updatePayload             *resourcemanager.ModelDetails
	updatePropertiesModelName *string
	updatePropertiesPayload   *resourcemanager.ModelDetails
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

func (p operationPayloads) createReadUpdatePayloadsProperties() []resourcemanager.ModelDetails {
	out := []resourcemanager.ModelDetails{
		p.createPropertiesPayload,
		p.readPropertiesPayload,
	}
	if p.updatePropertiesPayload != nil {
		out = append(out, *p.updatePropertiesPayload)
	}

	return out
}

func (p operationPayloads) getPropertiesModelWithinModel(input resourcemanager.ModelDetails, models map[string]resourcemanager.ModelDetails) (*string, *resourcemanager.ModelDetails) {
	if props, ok := getField(input, "Properties"); ok {
		if props.ObjectDefinition.Type != resourcemanager.ReferenceApiObjectDefinitionType {
			return nil, nil
		}

		modelName := *props.ObjectDefinition.ReferenceName
		model, ok := models[modelName]
		if !ok {
			return nil, nil
		}

		return &modelName, &model
	}

	return nil, nil
}
