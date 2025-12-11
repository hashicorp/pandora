// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/mappings"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForMappings(input models.ResourceInput) (*string, error) {
	lines := make([]string, 0)

	helper := mappings.NewResourceMappings(input.Details, input.Constants, input.Models)

	for _, modelToModel := range input.Details.Mappings.ModelToModels {
		mappingsForThisModel, err := mappings.FindMappingsBetween(modelToModel, input.Details.Mappings.Fields)
		if err != nil {
			return nil, fmt.Errorf("finding mappings between Schema Model %q and Sdk Model %q: %+v", modelToModel.TerraformSchemaModelName, modelToModel.SDKModelName, err)
		}

		schemaToSdkLines, err := helper.SchemaModelToSdkModelAssignmentLine(*mappingsForThisModel)
		if err != nil {
			return nil, fmt.Errorf("building mappings from Schema Models to Sdk Models: %+v", err)
		}
		sdkToSchemaLines, err := helper.SdkModelToSchemaModelAssignmentLine(*mappingsForThisModel)
		if err != nil {
			return nil, fmt.Errorf("building mappings from Sdk Models to Schema Models: %+v", err)
		}

		// Schema -> SDK
		lines = append(lines, fmt.Sprintf(`
func (r %[1]sResource) map%[2]sTo%[3]s(input %[2]s, output *%[4]s.%[3]s) error {
	%[5]s
	return nil
}
`, input.Details.ResourceName, modelToModel.TerraformSchemaModelName, modelToModel.SDKModelName, strings.ToLower(input.SdkResourceName), *schemaToSdkLines))

		// SDK -> Schema
		lines = append(lines, fmt.Sprintf(`
func (r %[1]sResource) map%[2]sTo%[3]s(input %[4]s.%[2]s, output *%[3]s) error {
	%[5]s
	return nil
}
`, input.Details.ResourceName, modelToModel.SDKModelName, modelToModel.TerraformSchemaModelName, strings.ToLower(input.SdkResourceName), *sdkToSchemaLines))
	}

	output := strings.Join(lines, "\n")
	return &output, nil
}
