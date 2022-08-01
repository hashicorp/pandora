package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func definitionForResource(input models.ResourceInput) (*string, error) {
	// TODO: outputting a `ResourceWithUpdate` if this is an Update too (by the update func?)
	output := fmt.Sprintf(`
var _ sdk.Resource = %[1]sResource{}

type %[1]sResource struct {}
`, input.ResourceTypeName)
	return &output, nil
}
