package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForTopLevelTypedModelAndDefinition(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf(`
type %[2]s struct {
	// TODO: this is purely a placeholder to make it compile for now
}

func (r %[1]sResource) ModelObject() interface{} {
	// TODO: implement me in the generator
	return &%[2]s{}
}
`, input.ResourceTypeName, input.SchemaModelName)
	return &output, nil
}
