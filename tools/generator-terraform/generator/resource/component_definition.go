package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func definitionForResource(input models.ResourceInput) string {
	// TODO: outputting a `ResourceWithUpdate` if this is an Update too (by the update func?)
	return fmt.Sprintf(`
var _ sdk.Resource = %[1]sResource{}

type %[1]sResource struct {}
`, input.ResourceTypeName)
}
