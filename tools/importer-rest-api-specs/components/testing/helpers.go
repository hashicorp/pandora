package testing

import (
	"fmt"

	"github.com/hashicorp/hcl/v2/hclwrite"
)

func blockForResource(f *hclwrite.File, providerPrefix, resourceLabel, resourceLabelType string) *hclwrite.Body {
	fullResourceLabel := fmt.Sprintf("%s_%s", providerPrefix, resourceLabel)
	return f.Body().AppendNewBlock("resource", []string{
		fullResourceLabel,
		resourceLabelType,
	}).Body()
}
