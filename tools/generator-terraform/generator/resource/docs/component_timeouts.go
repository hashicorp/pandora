package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForTimeouts(input models.ResourceInput) (*string, error) {
	createTimeout := wordifyTimeout(input.Details.CreateMethod.TimeoutInMinutes)
	readTimeout := wordifyTimeout(input.Details.ReadMethod.TimeoutInMinutes)
	deleteTimeout := wordifyTimeout(input.Details.DeleteMethod.TimeoutInMinutes)

	lines := []string{
		fmt.Sprintf("* 'create' - (Defaults to %[2]s) Used when creating this %[1]s.", input.Details.DisplayName, createTimeout),
		fmt.Sprintf("* 'delete' - (Defaults to %[2]s) Used when deleting this %[1]s.", input.Details.DisplayName, deleteTimeout),
		fmt.Sprintf("* 'read' - (Defaults to %[2]s) Used when retrieving this %[1]s.", input.Details.DisplayName, readTimeout),
	}
	if input.Details.UpdateMethod != nil {
		updateTimeout := wordifyTimeout(input.Details.UpdateMethod.TimeoutInMinutes)
		lines = append(lines, fmt.Sprintf("* 'update' - (Defaults to %[2]s) Used when updating this %[1]s.", input.Details.DisplayName, updateTimeout))
	}
	output := fmt.Sprintf(`
## Timeouts

The 'timeouts' block allows you to specify [timeouts](https://www.terraform.io/docs/configuration/resources.html#timeouts) for certain actions:

%[1]s
`, strings.Join(lines, "\n"))
	output = strings.ReplaceAll(output, "'", "`")
	return &output, nil
}
