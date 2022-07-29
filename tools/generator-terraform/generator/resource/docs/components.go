package docs

import "github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

func ComponentsForResource(input models.ResourceInput) []string {
	return []string{
		codeForYAMLFrontMatter(input),
		codeForSummary(input),
		codeForExampleUsage(input),
		codeForArgumentsReference(input),
		codeForAttributesReference(input),
		codeForTimeouts(input),
		codeForImport(input),
	}
}
