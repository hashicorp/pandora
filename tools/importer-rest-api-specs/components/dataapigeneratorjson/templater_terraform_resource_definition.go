package dataapigeneratorjson

import (
	"encoding/json"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceDefinition(resourceLabel string, details resourcemanager.TerraformResourceDetails, resourceIds map[string]importerModels.ParsedResourceId) ([]byte, error) {
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

	resourceDefinition := dataApiModels.TerraformResourceDefinition{
		DisplayName:    details.DisplayName,
		ResourceIdName: details.ResourceIdName,
		Label:          resourceLabel,
		Category:       details.Documentation.Category,
		Description:    details.Documentation.Description,
		ExampleUsage:   details.Documentation.ExampleUsageHcl,
		// todo thread these through to the resource config
		GenerateIDValidationFunction: true,
		GenerateModel:                true,
		GenerateSchema:               true,
		CreateMethod:                 createMethod,
		DeleteMethod:                 deleteMethod,
		ReadMethod:                   readMethod,
		UpdateMethod:                 pointer.To(updateMethod),
	}

	data, err := json.MarshalIndent(resourceDefinition, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}
