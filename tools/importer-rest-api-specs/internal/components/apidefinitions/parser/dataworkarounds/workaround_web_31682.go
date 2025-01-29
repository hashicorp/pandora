package dataworkarounds

import (
	"fmt"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundWeb31682{}

type workaroundWeb31682 struct {
}

func (workaroundWeb31682) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Web" && apiVersion.APIVersion == "2016-06-01"
}

func (workaroundWeb31682) Name() string {
	return "Web / 31682"
}

func (workaroundWeb31682) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Connections"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Connections` but didn't get one")
	}
	model, ok := resource.Models["ApiConnectionDefinitionProperties"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model `ApiConnectionDefinitionProperties`")
	}
	fields := []string{
		"CustomParameterValues",
		"NonSecretParameterValues",
		"ParameterValues",
	}

	for _, field := range fields {
		f, ok := model.Fields[field]
		if !ok {
			return nil, fmt.Errorf("couldn't find the field `%s` in model `ApiConnectionDefinitionProperties`", field)
		}
		if f.ObjectDefinition.NestedItem != nil {
			f.ObjectDefinition.NestedItem.Type = "RawObject"
		}

		model.Fields[field] = f
	}
	resource.Models["ApiConnectionDefinitionProperties"] = model
	input.Resources["Connections"] = resource

	return &input, nil
}
