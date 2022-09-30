package docs

import (
	"fmt"
	"regexp"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForExampleUsage(input models.ResourceInput) (*string, error) {
	example := convertBasicTestToUsableExample(input.Details.Tests)
	code := strings.TrimSpace(fmt.Sprintf(`
## Example Usage

'''hcl
%[1]s
'''
`, example))
	output := strings.ReplaceAll(code, "'", "`")
	return &output, nil
}

func convertBasicTestToUsableExample(tests resourcemanager.TerraformResourceTestsDefinition) string {
	// TODO add the template config once it's filled with the prerequisite resources
	example := strings.Replace(tests.BasicConfiguration, "test", "example", -1)
	example = strings.Replace(example, "acc", "", -1)
	re := regexp.MustCompile("[-][$][{](.*)[}]")
	example = re.ReplaceAllLiteralString(example, "")

	testVariables := map[string]string{
		// TODO: add more
		"random_integer":   "21",
		"primary_location": "West Europe",
	}
	for variable, replacement := range testVariables {
		example = strings.ReplaceAll(example, fmt.Sprintf("${local.%s}", variable), replacement)
		example = strings.ReplaceAll(example, fmt.Sprintf("local.%s", variable), replacement)
	}

	example = strings.TrimSpace(example)
	return example
}
