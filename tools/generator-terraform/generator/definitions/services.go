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

	// Generate the Client for this Service Package
	clientsFilePath := fmt.Sprintf("%s/client.gen.go", clientsDirectory)
	os.Remove(clientsFilePath)
	clientContents := codeForClientsRegistration(input)
	writeToPath(clientsFilePath, clientContents)

	// ensure the provider directory exists
	providerDirectory := fmt.Sprintf("%s/internal/provider", input.RootDirectory)
	os.MkdirAll(providerDirectory, 0755)

	// Generate the Services Registration file
	servicesRegistrationFilePath := fmt.Sprintf("%s/services.gen.go", providerDirectory)
	os.Remove(servicesRegistrationFilePath)
	servicesRegistrationCode := codeForServicesRegistration(input)
	writeToPath(servicesRegistrationFilePath, servicesRegistrationCode)

	return nil
}
