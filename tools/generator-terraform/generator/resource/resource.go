package resource

import (
	"fmt"
	"os"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/resource/docs"
)

func Resource(input models.ResourceInput) error {
	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	os.MkdirAll(serviceDirectory, 0755)

	// TODO: generating Tests and Docs

	resourceFilePath := fmt.Sprintf("%s/%s_resource.gen.go", serviceDirectory, input.ResourceLabel)
	// remove the file if it already exists
	os.Remove(resourceFilePath)
	resourceCode, err := codeForResource(input)
	if err != nil {
		return fmt.Errorf("building code for resource: %+v", err)
	}
	writeToPath(resourceFilePath, *resourceCode)

	// then go generate the documentation
	websiteResourcesDirectory := fmt.Sprintf("%s/website/r/", input.RootDirectory)
	os.MkdirAll(websiteResourcesDirectory, 0755)
	documentationFilePath := fmt.Sprintf("%s/%s.html.markdown", websiteResourcesDirectory, input.ResourceLabel)
	// remove the file if it already exists
	os.Remove(documentationFilePath)
	documentationForResource, err := docs.ComponentsForResource(input)
	if err != nil {
		return fmt.Errorf("building documentation for resource: %+v", err)
	}
	writeToPath(documentationFilePath, *documentationForResource)

	return nil
}
