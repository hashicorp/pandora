package dataapigeneratorjson

import (
	"encoding/json"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ResourceDefinition struct {
	DisplayName                  string `json:"DisplayName"`
	Id                           string `json:"Id"`
	Label                        string `json:"Label"`
	Category                     string `json:"Category"`
	Description                  string `json:"Description"`
	ExampleUsage                 string `json:"ExampleUsage"`
	GenerateIDValidationFunction bool   `json:"GenerateIDValidationFunction"`
	GenerateModel                bool   `json:"GenerateModel"`
	GenerateSchema               bool   `json:"GenerateSchema"`
	CreateMethod                 Method `json:"CreateMethod"`
	DeleteMethod                 Method `json:"DeleteMethod"`
	ReadMethod                   Method `json:"ReadMethod"`
	UpdateMethod                 Method `json:"UpdateMethod"`
}

type Method struct {
	Generate         bool   `json:"Generate"`
	Name             string `json:"Name"`
	TimeoutInMinutes int    `json:"TimeoutInMinutes"`
}

func codeForTerraformResourceDefinition(apiVersion, apiResource, resourceLabel string, details resourcemanager.TerraformResourceDetails) ([]byte, error) {
	createMethod := Method{
		Generate:         details.CreateMethod.Generate,
		Name:             details.CreateMethod.MethodName,
		TimeoutInMinutes: details.CreateMethod.TimeoutInMinutes,
	}
	deleteMethod := Method{
		Generate:         details.DeleteMethod.Generate,
		Name:             details.DeleteMethod.MethodName,
		TimeoutInMinutes: details.DeleteMethod.TimeoutInMinutes,
	}
	readMethod := Method{
		Generate:         details.ReadMethod.Generate,
		Name:             details.ReadMethod.MethodName,
		TimeoutInMinutes: details.ReadMethod.TimeoutInMinutes,
	}
	updateMethod := Method{
		Generate:         details.UpdateMethod.Generate,
		Name:             details.UpdateMethod.MethodName,
		TimeoutInMinutes: details.UpdateMethod.TimeoutInMinutes,
	}

	resourceDefinition := ResourceDefinition{
		DisplayName: details.DisplayName,
		// todo figure this out
		Id:           details.ResourceIdName,
		Label:        resourceLabel,
		Category:     details.Documentation.Category,
		Description:  details.Documentation.Description,
		ExampleUsage: details.Documentation.ExampleUsageHcl,
		// todo thread these through to the resource config
		GenerateIDValidationFunction: true,
		GenerateModel:                true,
		GenerateSchema:               true,
		CreateMethod:                 createMethod,
		DeleteMethod:                 deleteMethod,
		ReadMethod:                   readMethod,
		UpdateMethod:                 updateMethod,
	}

	data, err := json.MarshalIndent(resourceDefinition, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}
