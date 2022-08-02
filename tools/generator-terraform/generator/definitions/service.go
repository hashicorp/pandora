package definitions

import (
	"fmt"
	"os"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func ForService(input models.ServiceInput) error {
	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	os.MkdirAll(serviceDirectory, 0755)

	// ensure the Client directory exists
	serviceClientDirectory := fmt.Sprintf("%s/client", serviceDirectory)
	os.MkdirAll(serviceClientDirectory, 0755)

	// Generate the Client for this Service Package
	clientFilePath := fmt.Sprintf("%s/client.gen.go", serviceClientDirectory)
	os.Remove(clientFilePath)
	clientContents := templateForServiceClient(input)
	writeToPath(clientFilePath, clientContents)

	// Generate the Registration for this Service Package
	registrationFilePath := fmt.Sprintf("%s/registration.gen.go", serviceDirectory)
	os.Remove(registrationFilePath)
	registrationContents := templateForServiceRegistration(input)
	writeToPath(registrationFilePath, registrationContents)

	return nil
}
