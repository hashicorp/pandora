package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundDataFactory23013{}

// workaroundDataFactory23013 works around the `IntegrationRuntimeReference` and `LinkedServiceReference` models both
// defining a `type` field indicating that these are discriminated types but not defined as a Discriminated Type
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/23013
type workaroundDataFactory23013 struct{}

func (workaroundDataFactory23013) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "DataFactory" && apiDefinition.ApiVersion == "2018-06-01"
}

func (workaroundDataFactory23013) Name() string {
	return "DataFactory / 23013"
}

func (workaroundDataFactory23013) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["DataFlowDebugSession"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource DataFlowDebugSession")
	}

	// add the new discriminated parent type
	resource.Models["Reference"] = models.ModelDetails{
		TypeHintIn: pointer.To("Type"),
		Fields: map[string]models.FieldDetails{
			"Type": {
				ObjectDefinition: &models.ObjectDefinition{
					Type: models.ObjectDefinitionString,
				},
				Required: true,
				JsonName: "type",
			},
		},
	}

	// update the existing models to be discriminated types and remove the `type` field from them
	// ` and `LinkedServiceReference
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

	// delete the now unused `Type` constant
	delete(resource.Constants, "Type")

	apiDefinition.Resources["DataFlowDebugSession"] = resource
	return &apiDefinition, nil
}
