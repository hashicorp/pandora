package generator

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ResourceInput struct {
	ProviderPrefix     string
	ResourceLabel      string
	RootDirectory      string
	ServicePackageName string
	Details            resourcemanager.TerraformResourceDetails
}

func Resource(input ResourceInput) error {
	log.Printf("TODO: Resource stuff")

	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	os.MkdirAll(serviceDirectory, 0755)

	filePath := fmt.Sprintf("%s/%s_resource.gen.go", serviceDirectory, input.ResourceLabel)
	fileContents := fmt.Sprintf(`package %s

// TODO
`, input.ServicePackageName)
	os.WriteFile(filePath, []byte(fileContents), 0644)

	return nil
}
