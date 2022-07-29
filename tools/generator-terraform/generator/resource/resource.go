package resource

import (
	"fmt"
	"os"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/resource/docs"
)

func Resource(input models.ResourceInput) error {
	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	os.MkdirAll(serviceDirectory, 0755)

	// TODO: generating Tests and Docs
	testFilePath := fmt.Sprintf("%s/%s_resource_test.gen.go", serviceDirectory, input.ResourceLabel)
	// remove the file if it already exists
	os.Remove(testFilePath)
	testComponents := componentsForResourceTest(input)
	writeToPath(testFilePath, strings.Join(testComponents, "\n"))

	resourceFilePath := fmt.Sprintf("%s/%s_resource.gen.go", serviceDirectory, input.ResourceLabel)
	// remove the file if it already exists
	os.Remove(resourceFilePath)
	resourceComponents := componentsForResource(input)
	writeToPath(resourceFilePath, strings.Join(resourceComponents, "\n"))

	// then go generate the documentation
	websiteResourcesDirectory := fmt.Sprintf("%s/website/r/", input.RootDirectory)
	os.MkdirAll(websiteResourcesDirectory, 0755)
	documentationFilePath := fmt.Sprintf("%s/%s.html.markdown", websiteResourcesDirectory, input.ResourceLabel)
	// remove the file if it already exists
	os.Remove(documentationFilePath)
	documentationComponents := docs.ComponentsForResource(input)
	writeToPath(documentationFilePath, strings.Join(documentationComponents, "\n\n"))

	return nil
}
