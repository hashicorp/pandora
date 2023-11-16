package dataapigeneratorjson

import (
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func buildTerraformResourceDefinition(resourceLabel string, input resourcemanager.TerraformResourceDetails) (*dataApiModels.TerraformResourceDefinition, error) {
	// TODO: ExampleUsage should probably go out into a file - perhaps `Resource-ExampleUsage.hcl`?
	output := dataApiModels.TerraformResourceDefinition{
		ApiVersion: input.ApiVersion,
		Category:   input.Documentation.Category,
		CreateMethod: dataApiModels.TerraformMethodDefinition{
			Generate:         input.CreateMethod.Generate,
			Name:             input.CreateMethod.MethodName,
			TimeoutInMinutes: input.CreateMethod.TimeoutInMinutes,
		},
		DeleteMethod: dataApiModels.TerraformMethodDefinition{
			Generate:         input.DeleteMethod.Generate,
			Name:             input.DeleteMethod.MethodName,
			TimeoutInMinutes: input.DeleteMethod.TimeoutInMinutes,
		},
		Description:                  input.Documentation.Description,
		DisplayName:                  input.DisplayName,
		ExampleUsage:                 input.Documentation.ExampleUsageHcl,
		Generate:                     input.Generate,
		GenerateIdValidationFunction: input.GenerateIdValidation,
		GenerateModel:                input.GenerateModel,
		GenerateSchema:               input.GenerateSchema,
		Label:                        resourceLabel,
		ReadMethod: dataApiModels.TerraformMethodDefinition{
			Generate:         input.ReadMethod.Generate,
			Name:             input.ReadMethod.MethodName,
			TimeoutInMinutes: input.ReadMethod.TimeoutInMinutes,
		},
		Resource:        input.Resource,
		ResourceIdName:  input.ResourceIdName,
		SchemaModelName: input.SchemaModelName,
		UpdateMethod:    nil,
	}
	if input.UpdateMethod != nil {
		output.UpdateMethod = &dataApiModels.TerraformMethodDefinition{
			Generate:         input.UpdateMethod.Generate,
			Name:             input.UpdateMethod.MethodName,
			TimeoutInMinutes: input.UpdateMethod.TimeoutInMinutes,
		}
	}

	return &output, nil
}
