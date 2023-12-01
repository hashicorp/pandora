package dataapigeneratorjson

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"strings"
)

func buildTerraformResourceDefinition(resourceLabel string, input resourcemanager.TerraformResourceDetails) (*dataapimodels.TerraformResourceDefinition, error) {
	// TODO: ExampleUsage should probably go out into a file - perhaps `Resource-ExampleUsage.hcl`?
	output := dataapimodels.TerraformResourceDefinition{
		ApiVersion: input.ApiVersion,
		Category:   input.Documentation.Category,
		CreateMethod: dataapimodels.TerraformMethodDefinition{
			Generate:         input.CreateMethod.Generate,
			Name:             input.CreateMethod.MethodName,
			TimeoutInMinutes: input.CreateMethod.TimeoutInMinutes,
		},
		DeleteMethod: dataapimodels.TerraformMethodDefinition{
			Generate:         input.DeleteMethod.Generate,
			Name:             input.DeleteMethod.MethodName,
			TimeoutInMinutes: input.DeleteMethod.TimeoutInMinutes,
		},
		Description:                  input.Documentation.Description,
		DisplayName:                  input.DisplayName,
		ExampleUsage:                 strings.TrimPrefix(strings.TrimSuffix(input.Documentation.ExampleUsageHcl, "\n"), "\n"),
		Generate:                     input.Generate,
		GenerateIdValidationFunction: input.GenerateIdValidation,
		GenerateModel:                input.GenerateModel,
		GenerateSchema:               input.GenerateSchema,
		Label:                        resourceLabel,
		ReadMethod: dataapimodels.TerraformMethodDefinition{
			Generate:         input.ReadMethod.Generate,
			Name:             input.ReadMethod.MethodName,
			TimeoutInMinutes: input.ReadMethod.TimeoutInMinutes,
		},
		Resource:       input.Resource,
		ResourceIdName: input.ResourceIdName,
		// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
		SchemaModelName: fmt.Sprintf("%sSchema", input.SchemaModelName),
		UpdateMethod:    nil,
	}
	if input.UpdateMethod != nil {
		output.UpdateMethod = &dataapimodels.TerraformMethodDefinition{
			Generate:         input.UpdateMethod.Generate,
			Name:             input.UpdateMethod.MethodName,
			TimeoutInMinutes: input.UpdateMethod.TimeoutInMinutes,
		}
	}

	return &output, nil
}
