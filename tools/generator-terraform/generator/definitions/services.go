package definitions

import (
	"fmt"
	"os"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func DefinitionForServices(input models.ServicesInput) error {
	// ensure the clients directory exists
	clientsDirectory := fmt.Sprintf("%s/internal/clients", input.RootDirectory)
	os.MkdirAll(clientsDirectory, 0755)

	// ensure the Client directory exists
	// Generate the Client for this Service Package
	clientsFilePath := fmt.Sprintf("%s/client.gen.go", clientsDirectory)
	os.Remove(clientsFilePath)
	clientContents := codeForServicesRegistration(input)
	writeToPath(clientsFilePath, clientContents)

	return nil
}
