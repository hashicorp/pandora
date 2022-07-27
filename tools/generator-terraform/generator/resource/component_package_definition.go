package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func packageDefinitionForResource(input models.ResourceInput) string {
	return fmt.Sprintf("package %s", input.ServicePackageName)
}
