package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func ComponentsForResource(input models.ResourceInput) (*string, error) {
	components := []func(input models.ResourceInput) (*string, error){
		codeForYAMLFrontMatter,
		codeForGeneratedNote,
		codeForSummary,
		codeForExampleUsage,
		// TODO: links to examples
		codeForArgumentsReference,
		codeForAttributesReference,
		codeForBlocksReference,
		codeForTimeouts,
		codeForImport,
	}
	lines := make([]string, 0)
	for i, component := range components {
		result, err := component(input)
		if err != nil {
			return nil, fmt.Errorf("templating component %d: %+v", i, err)
		}
		if result != nil {
			lines = append(lines, strings.TrimSpace(*result))
		}
	}

	output := strings.Join(lines, "\n\n")
	return &output, nil
}
