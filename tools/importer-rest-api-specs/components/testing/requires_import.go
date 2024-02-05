// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (tb TestBuilder) generateRequiresImportTest() (*string, error) {
	// The RequiresImport test should call the basic test, thus each field we can map directly from the value for the basic test

	// NOTE: The RequiresImport test _should not_ include the features
	//       block, since it has a dependency on the Basic test.

	f := hclwrite.NewEmptyFile()

	model, ok := tb.details.SchemaModels[tb.details.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("the schema model %q was not found", tb.details.SchemaModelName)
	}
	resource := blockForResource(f, tb.providerPrefix, tb.resourceLabel, "import")
	currentResourceLabel := fmt.Sprintf("%s_%s.test", tb.providerPrefix, tb.resourceLabel)
	if err := tb.populateFieldsForResourceImport(resource, model, currentResourceLabel); err != nil {
		return nil, fmt.Errorf("populating test fields for model %q: %+v", tb.details.SchemaModelName, err)
	}

	output := string(hclwrite.Format(f.Bytes()))
	return &output, nil
}

func (tb TestBuilder) populateFieldsForResourceImport(block *hclwrite.Body, model resourcemanager.TerraformSchemaModelDefinition, currentResourceLabel string) error {
	requiredFields := getRequiredFieldsForSchemaModel(model)

	for _, field := range requiredFields {
		// TODO: if it's a List or Set

		if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			nestedModel, ok := tb.details.SchemaModels[*field.ObjectDefinition.ReferenceName]
			if !ok {
				return fmt.Errorf("the nested schema model %q was not found for field %q", *field.ObjectDefinition.ReferenceName, field.HclName)
			}

			nested := block.AppendNewBlock(field.HclName, []string{}).Body()
			if err := tb.populateFieldsForResourceImport(nested, nestedModel, fmt.Sprintf("%s.%s.0", currentResourceLabel, field.HclName)); err != nil {
				return fmt.Errorf("populating nested model for %q: %+v", field.HclName, err)
			}

			continue
		}

		block.SetAttributeTraversal(field.HclName, hcl.Traversal{
			hcl.TraverseRoot{
				Name: fmt.Sprintf("%s.%s", currentResourceLabel, field.HclName),
			},
		})
	}

	return nil
}
