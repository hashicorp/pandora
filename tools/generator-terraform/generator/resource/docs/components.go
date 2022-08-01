package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func ComponentsForResource(input models.ResourceInput) (*string, error) {
	components := []func(input models.ResourceInput) (*string, error){
		codeForYAMLFrontMatter,
		codeForSummary,
		codeForExampleUsage,
		codeForArgumentsReference,
		codeForAttributesReference,
		codeForTimeouts,
		codeForImport,
	}
	lines := make([]string, 0)
	for i, component := range components {
		result, err := component(input)
		if err != nil {
			return nil, fmt.Errorf("templating component %d: %+v", i, err)
		}
		lines = append(lines, *result)
	}

	output := strings.Join(lines, "\n\n")
	return &output, nil
}
