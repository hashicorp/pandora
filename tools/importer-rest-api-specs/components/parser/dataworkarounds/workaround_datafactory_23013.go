// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundDataFactory23013{}

// workaroundDataFactory23013 works around the `IntegrationRuntimeReference` and `LinkedServiceReference` models both
// defining a `type` field indicating that these are discriminated types but not defined as a Discriminated Type
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/23013
type workaroundDataFactory23013 struct{}

func (workaroundDataFactory23013) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "DataFactory" && apiDefinition.ApiVersion == "2018-06-01"
}

func (workaroundDataFactory23013) Name() string {
	return "DataFactory / 23013"
}

func (workaroundDataFactory23013) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["DataFlowDebugSession"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource DataFlowDebugSession")
	}

	// add the new discriminated parent type
	resource.Models["Reference"] = importerModels.ModelDetails{
		TypeHintIn: pointer.To("Type"),
		Fields: map[string]importerModels.FieldDetails{
			"Type": {
				ObjectDefinition: models.SDKObjectDefinition{
					Type: models.StringSDKObjectDefinitionType,
				},
				Required: true,
				JsonName: "type",
			},
		},
	}

	// update the existing importerModels to be discriminated types and remove the `type` field from them
	modelNames := []string{
		"IntegrationRuntimeReference",
		"LinkedServiceReference",
	}
	for _, modelName := range modelNames {
		model, ok := resource.Models[modelName]
		if !ok {
			return nil, fmt.Errorf("couldn't find model %q", modelName)
		}
		delete(model.Fields, "Type")
		model.ParentTypeName = pointer.To("Reference")
		model.TypeHintIn = pointer.To("Type")
		model.TypeHintValue = pointer.To(modelName)
		resource.Models[modelName] = model
	}

	// we need to update the usages of the discriminated types to use the parent
	usages := map[string]string{
		"LinkedService":       "ConnectVia",
		"Dataset":             "LinkedServiceName",
		"DataFlowStagingInfo": "LinkedService",
	}

	for modelName, fieldName := range usages {
		model, ok := resource.Models[modelName]
		if !ok {
			return nil, fmt.Errorf("couldn't find model %q", modelName)
		}
		field, ok := model.Fields[fieldName]
		if !ok {
			return nil, fmt.Errorf("couldn't find field %q in model %q", fieldName, modelName)
		}
		field.ObjectDefinition.ReferenceName = pointer.To("Reference")

		model.Fields[fieldName] = field
		resource.Models[modelName] = model
	}

	// delete the now unused `Type` constant
	delete(resource.Constants, "Type")

	apiDefinition.Resources["DataFlowDebugSession"] = resource
	return &apiDefinition, nil
}
