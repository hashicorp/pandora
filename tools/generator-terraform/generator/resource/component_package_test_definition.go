package resource

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func packageTestDefinitionForResource(input models.ResourceInput) string {
	return fmt.Sprintf("package %s_test", input.ServicePackageName)
}
