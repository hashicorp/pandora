package dataapigeneratorjson

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func buildTerraformResourceDefinition(resourceLabel string, details resourcemanager.TerraformResourceDetails) (*dataApiModels.TerraformResourceDefinition, error) {
	createMethod := dataApiModels.TerraformMethodDefinition{
		Generate:         details.CreateMethod.Generate,
		Name:             details.CreateMethod.MethodName,
		TimeoutInMinutes: details.CreateMethod.TimeoutInMinutes,
	}
	deleteMethod := dataApiModels.TerraformMethodDefinition{
		Generate:         details.DeleteMethod.Generate,
		Name:             details.DeleteMethod.MethodName,
		TimeoutInMinutes: details.DeleteMethod.TimeoutInMinutes,
	}
	readMethod := dataApiModels.TerraformMethodDefinition{
		Generate:         details.ReadMethod.Generate,
		Name:             details.ReadMethod.MethodName,
		TimeoutInMinutes: details.ReadMethod.TimeoutInMinutes,
	}
	updateMethod := dataApiModels.TerraformMethodDefinition{
		Generate:         details.UpdateMethod.Generate,
		Name:             details.UpdateMethod.MethodName,
		TimeoutInMinutes: details.UpdateMethod.TimeoutInMinutes,
	}
	//TODO: Update is optional

	resourceDefinition := dataApiModels.TerraformResourceDefinition{
		DisplayName:    details.DisplayName,
		ResourceIdName: details.ResourceIdName,
		Label:          resourceLabel,
		Category:       details.Documentation.Category,
		Description:    details.Documentation.Description,
		ExampleUsage:   details.Documentation.ExampleUsageHcl,
		// todo thread these through to the resource config
		GenerateIdValidationFunction: true,
		GenerateModel:                true,
		GenerateSchema:               true,
		CreateMethod:                 createMethod,
		DeleteMethod:                 deleteMethod,
		ReadMethod:                   readMethod,
		UpdateMethod:                 pointer.To(updateMethod),
	}
	return &resourceDefinition, nil
}
