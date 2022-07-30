package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForTimeouts(input models.ResourceInput) (*string, error) {
	createTimeout, err := wordifyTimeout(input.Details.CreateMethod.TimeoutInMinutes)
	if err != nil {
		return nil, fmt.Errorf("wordifying Create Timeout %dm: %+v", input.Details.CreateMethod.TimeoutInMinutes, err)
	}
	readTimeout, err := wordifyTimeout(input.Details.ReadMethod.TimeoutInMinutes)
	if err != nil {
		return nil, fmt.Errorf("wordifying Read Timeout %dm: %+v", input.Details.ReadMethod.TimeoutInMinutes, err)
	}
	deleteTimeout, err := wordifyTimeout(input.Details.DeleteMethod.TimeoutInMinutes)
	if err != nil {
		return nil, fmt.Errorf("wordifying Delete Timeout %dm: %+v", input.Details.DeleteMethod.TimeoutInMinutes, err)
	}

	lines := []string{
		fmt.Sprintf("* 'create' - (Defaults to %[2]s) Used when creating this %[1]s.", input.Details.DisplayName, *createTimeout),
		fmt.Sprintf("* 'delete' - (Defaults to %[2]s) Used when deleting this %[1]s.", input.Details.DisplayName, *deleteTimeout),
		fmt.Sprintf("* 'read' - (Defaults to %[2]s) Used when retrieving this %[1]s.", input.Details.DisplayName, *readTimeout),
	}
	if input.Details.UpdateMethod != nil {
		updateTimeout, err := wordifyTimeout(input.Details.UpdateMethod.TimeoutInMinutes)
		if err != nil {
			return nil, fmt.Errorf("wordifying Update Timeout %dm: %+v", input.Details.UpdateMethod.TimeoutInMinutes, err)
		}
		lines = append(lines, fmt.Sprintf("* 'update' - (Defaults to %[1]s) Used when updating this %[1]s.", input.Details.DisplayName, *updateTimeout))
	}
	output := fmt.Sprintf(`
## Timeouts

The 'timeouts' block allows you to specify [timeouts](https://www.terraform.io/docs/configuration/resources.html#timeouts) for certain actions:

%[1]s
`, strings.Join(lines, "\n"))
	output = strings.ReplaceAll(output, "'", "`")
	return &output, nil
}

func wordifyTimeout(inMinutes int) (*string, error) {
	// TODO: make this better
	output := fmt.Sprintf("%d minutes", inMinutes)
	return &output, nil
}
