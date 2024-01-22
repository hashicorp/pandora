// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/helpers"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForTopLevelTypedModelAndDefinition(input models.ResourceInput) (*string, error) {
	if !input.Details.GenerateModel {
		return nil, nil
	}

	schemaModel, ok := input.SchemaModels[input.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("schema model named %q was not found", input.SchemaModelName)
	}

	codeForTopLevelModel, err := codeForModel(input.SchemaModelName, schemaModel)
	if err != nil {
		return nil, fmt.Errorf("building code for top-level schema model %q: %+v", input.SchemaModelName, err)
	}

	output := fmt.Sprintf(`
func (r %[1]sResource) ModelObject() interface{} {
	return &%[2]s{}
}

%[3]s
`, input.ResourceTypeName, input.SchemaModelName, *codeForTopLevelModel)
	return &output, nil
}

func codeForNonTopLevelModels(input models.ResourceInput) (*string, error) {
	if !input.Details.GenerateModel {
		return nil, nil
	}

	modelNames := make([]string, 0)
	for k := range input.SchemaModels {
		// top level models are output elsewhere
		if k == input.SchemaModelName {
			continue
		}

		modelNames = append(modelNames, k)
	}
	sort.Strings(modelNames)

	codeForModels := make([]string, 0)
	for _, modelName := range modelNames {
		model := input.SchemaModels[modelName]
		code, err := codeForModel(modelName, model)
		if err != nil {
			return nil, fmt.Errorf("generating code for model %q: %+v", modelName, err)
		}
		codeForModels = append(codeForModels, *code)
	}
	output := strings.Join(codeForModels, "\n")
	return &output, nil
}

func codeForModel(name string, input resourcemanager.TerraformSchemaModelDefinition) (*string, error) {
	schemaFields := make([]string, 0)
	for fieldName, fieldDetails := range input.Fields {
		golandFieldType, err := helpers.GolangFieldTypeFromObjectFieldDefinition(fieldDetails.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining Golang Field Type from ObjectDefinition for Field %q: %+v", fieldName, err)
		}

		// NOTE: Optional fields are intentionally not output as pointers since whilst these
		// may be omitted from the Terraform Configuration, we still parse them out/set them
		// back as an empty value at this point in time

		schemaFields = append(schemaFields, fmt.Sprintf("%s %s `tfschema:%q`", fieldName, *golandFieldType, fieldDetails.HclName))
	}
	sort.Strings(schemaFields)

	output := fmt.Sprintf(`
type %[1]s struct {
	%[2]s
}
`, name, strings.Join(schemaFields, "\n"))
	return &output, nil
}
