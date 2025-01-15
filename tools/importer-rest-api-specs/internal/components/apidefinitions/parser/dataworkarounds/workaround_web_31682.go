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
		return nil, fmt.Errorf("couldn't find Model AutoStorageBaseProperties")
	}
	cpvField, ok := model.Fields["CustomParameterValues"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field CustomParameterValues within model AutoStorageProperties")
	}
	if cpvField.ObjectDefinition.NestedItem != nil {
		cpvField.ObjectDefinition.NestedItem.Type = "RawObject"
	}

	nspvField, ok := model.Fields["NonSecretParameterValues"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field CustomParameterValues within model AutoStorageProperties")
	}
	if nspvField.ObjectDefinition.NestedItem != nil {
		nspvField.ObjectDefinition.NestedItem.Type = "RawObject"
	}

	pvField, ok := model.Fields["ParameterValues"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field CustomParameterValues within model AutoStorageProperties")
	}
	if pvField.ObjectDefinition.NestedItem != nil {
		pvField.ObjectDefinition.NestedItem.Type = "RawObject"
	}
	model.Fields["CustomParameterValues"] = cpvField
	model.Fields["NonSecretParameterValues"] = nspvField
	model.Fields["ParameterValues"] = pvField
	resource.Models["ApiConnectionDefinitionProperties"] = model
	input.Resources["Connections"] = resource

	return &input, nil
}
