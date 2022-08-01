package resource

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func testResourceStruct(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf("type %sResource struct{}", input.ResourceTypeName)
	return &output, nil
}
