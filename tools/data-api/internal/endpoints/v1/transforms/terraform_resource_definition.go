// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func MapTerraformResourceDefinitions(input map[string]repositories.TerraformResourceDetails) (*map[string]models.TerraformResourceDefinition, error) {
	output := make(map[string]models.TerraformResourceDefinition)
	for key, val := range input {
		mapped, err := mapTerraformResourceDefinition(val)
		if err != nil {
			return nil, fmt.Errorf("mapping TerraformResourceDefinition %q: %+v", key, err)
		}
		// intentionally using `label` and not key
		output[val.Label] = *mapped
	}
	return &output, nil
}

func mapTerraformResourceDefinition(input repositories.TerraformResourceDetails) (*models.TerraformResourceDefinition, error) {
	mappings, err := mapTerraformSchemaMappings(input.Mappings)
	if err != nil {
		return nil, fmt.Errorf("mapping schema mappings for %q: %+v", input.ResourceName, err)
	}

	schemaModels, err := mapTerraformSchemaModels(input.SchemaModels)
	if err != nil {
		return nil, fmt.Errorf("mapping schema models for %s: %+v", input.ResourceName, err)
	}

	output := models.TerraformResourceDefinition{
		APIVersion:   input.ApiVersion,
		CreateMethod: mapTerraformMethodDefinition(input.CreateMethod),
		DeleteMethod: mapTerraformMethodDefinition(input.DeleteMethod),
		Documentation: models.TerraformDocumentationDefinition{
			Category:        input.Documentation.Category,
			Description:     input.Documentation.Description,
			ExampleUsageHCL: strings.TrimPrefix(strings.TrimSuffix(input.Documentation.ExampleUsageHcl, "\n"), "\n"),
		},
		DisplayName:          input.DisplayName,
		Generate:             input.Generate,
		GenerateModel:        input.GenerateModel,
		GenerateIDValidation: input.GenerateIdValidation,
		GenerateSchema:       input.GenerateSchema,
		Mappings:             *mappings,
		ReadMethod:           mapTerraformMethodDefinition(input.ReadMethod),
		APIResource:          input.Resource,
		ResourceIDName:       input.ResourceIdName,
		ResourceName:         input.ResourceName,
		SchemaModelName:      input.SchemaModelName,
		SchemaModels:         *schemaModels,
		Tests: models.TerraformResourceTestsDefinition{
			BasicConfiguration:          input.Tests.BasicConfiguration,
			RequiresImportConfiguration: input.Tests.RequiresImportConfiguration,
			CompleteConfiguration:       input.Tests.CompleteConfiguration,
			Generate:                    input.Tests.Generate,
			OtherTests:                  &input.Tests.OtherTests,
			TemplateConfiguration:       input.Tests.TemplateConfiguration,
		},
	}
	if input.UpdateMethod != nil {
		mappedUpdate := mapTerraformMethodDefinition(*input.UpdateMethod)
		output.UpdateMethod = pointer.To(mappedUpdate)
	}

	// todo remove this when https://github.com/hashicorp/pandora/issues/3352 is fixed
	// tests won't be added unless Generate is true when writing this out in generatorjson/helpers.go writeTestsHclToFile
	// so we can set this to true if BasicConfiguration has been written out
	if output.Tests.BasicConfiguration != "" {
		output.Tests.Generate = true
	}

	return &output, nil
}

func mapTerraformMethodDefinition(input repositories.MethodDefinition) models.TerraformMethodDefinition {
	return models.TerraformMethodDefinition{
		Generate:         input.Generate,
		SDKOperationName: input.MethodName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}
