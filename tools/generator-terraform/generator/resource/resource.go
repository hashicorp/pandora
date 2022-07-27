package resource

import (
	"fmt"
	"os"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func Resource(input models.ResourceInput) error {
	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	os.MkdirAll(serviceDirectory, 0755)

	// TODO: generating Tests and Docs

	resourceFilePath := fmt.Sprintf("%s/%s_resource.gen.go", serviceDirectory, input.ResourceLabel)
	// remove the file if it already exists
	os.Remove(resourceFilePath)
	resourceComponents := componentsForResource(input)
	writeToPath(resourceFilePath, strings.Join(resourceComponents, "\n"))

	return nil
}
