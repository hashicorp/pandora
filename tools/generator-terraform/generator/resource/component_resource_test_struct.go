package resource

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func testResourceStruct(input models.ResourceInput) string {
	return fmt.Sprintf("type %sResource struct{}", input.ResourceTypeName)
}
