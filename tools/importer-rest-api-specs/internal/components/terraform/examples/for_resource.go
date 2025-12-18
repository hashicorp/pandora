// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package examples

import (
	"fmt"
	"strings"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclsyntax"
	"github.com/hashicorp/hcl/v2/hclwrite"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func exampleUsageForResource(input sdkModels.TerraformResourceTestsDefinition) (*string, error) {
	testTemplate := input.BasicConfiguration
	if input.TemplateConfiguration != nil {
		testTemplate = fmt.Sprintf("%s\n%s", *input.TemplateConfiguration, testTemplate)
	}

	// then parse the config, removing any `variable` blocks
	parsed, err := hclwrite.ParseConfig([]byte(testTemplate), "example-usage.hcl", hcl.InitialPos)
	if err != nil {
		return nil, fmt.Errorf("parsing the input test template to build the example usage: %+v", err)
	}
	for _, block := range parsed.Body().Blocks() {
		// Remove `locals`, `provider` and `variable` blocks since the Example Usage should be simplified
		if block.Type() == "locals" || block.Type() == "provider" || block.Type() == "variable" {
			parsed.Body().RemoveBlock(block)
			continue
		}

		if block.Type() == "resource" {
			// update the block label from `foo_example.test` to `foo_example.example`
			if len(block.Labels()) == 2 && block.Labels()[1] == "test" {
				block.SetLabels([]string{
					block.Labels()[0],
					"example",
				})
			}

			if err := updateAttributesForBlock(block.Labels()[0], block); err != nil {
				return nil, fmt.Errorf("updating attributes for top-level block %q (%q): %+v", block.Type(), strings.Join(block.Labels(), " / "), err)
			}
		}
	}

	out := string(hclwrite.Format(parsed.Bytes()))
	for strings.Contains(out, "\n\n") {
		out = strings.ReplaceAll(out, "\n\n", "\n")
	}
	return &out, nil
}

func updateAttributesForBlock(resourceKey string, block *hclwrite.Block) error {
	for fieldKey, val := range block.Body().Attributes() {
		tokens := val.BuildTokens([]*hclwrite.Token{})
		foundEquals := false
		valueTokens := make([]byte, 0)
		for _, token := range tokens {
			if token.Type == hclsyntax.TokenNewline {
				continue
			}

			if token.Type == hclsyntax.TokenEqual {
				foundEquals = true
				continue
			}
			if !foundEquals {
				continue
			}
			valueTokens = append(valueTokens, token.Bytes...)
		}

		updatedValue, err := updatedValueForAttribute(resourceKey, fieldKey, string(valueTokens))
		if err != nil {
			return fmt.Errorf("determining updated value for %q: %+v", fieldKey, err)
		}
		if updatedValue != nil {
			block.Body().SetAttributeRaw(fieldKey, *updatedValue)
		}
	}

	for _, val := range block.Body().Blocks() {
		if err := updateAttributesForBlock(resourceKey, val); err != nil {
			return fmt.Errorf("updating attributes for nested block %q (%q): %+v", block.Type(), strings.Join(block.Labels(), " / "), err)
		}
	}
	return nil
}
