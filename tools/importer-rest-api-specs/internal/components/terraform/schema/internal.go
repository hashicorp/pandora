// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type operationPayloads struct {
	createModelName string
	createPayload   models.SDKModel
	// TODO once #3588 has been resolved these should become pointers
	createPropertiesModelName string
	createPropertiesPayload   models.SDKModel

	readModelName string
	readPayload   models.SDKModel
	// TODO once #3588 has been resolved these should become pointers
	readPropertiesModelName string
	readPropertiesPayload   models.SDKModel

	updateModelName           *string
	updatePayload             *models.SDKModel
	updatePropertiesModelName *string
	updatePropertiesPayload   *models.SDKModel
}

func (p operationPayloads) createReadUpdatePayloads() []models.SDKModel {
	out := []models.SDKModel{
		p.createPayload,
		p.readPayload,
	}
	if p.updatePayload != nil {
		out = append(out, *p.updatePayload)
	}
	return out
}

func (p operationPayloads) createReadUpdatePayloadsProperties() []models.SDKModel {
	out := []models.SDKModel{
		p.createPropertiesPayload,
		p.readPropertiesPayload,
	}
	if p.updatePropertiesPayload != nil {
		out = append(out, *p.updatePropertiesPayload)
	}

	return out
}

func (p operationPayloads) getPropertiesModelWithinModel(input models.SDKModel, sdkModels map[string]models.SDKModel) (*string, *models.SDKModel) {
	if props, ok := getField(input, "Properties"); ok {
		if props.ObjectDefinition.Type != models.ReferenceSDKObjectDefinitionType {
			return nil, nil
		}

		modelName := *props.ObjectDefinition.ReferenceName
		model, ok := sdkModels[modelName]
		if !ok {
			return nil, nil
		}

		return &modelName, &model
	}

	return nil, nil
}
