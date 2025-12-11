// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package definitions

import (
	"fmt"
	"os"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/helpers"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func DefinitionForServices(input models.ServicesInput) error {
	// ensure the clients directory exists
	clientsDirectory := fmt.Sprintf("%s/internal/clients", input.RootDirectory)
	_ = os.MkdirAll(clientsDirectory, 0755)

	// Generate the Client for this Service Package
	clientsFilePath := fmt.Sprintf("%s/client_gen.go", clientsDirectory)
	_ = os.Remove(clientsFilePath)
	clientContents := codeForClientsRegistration(input)
	helpers.WriteToPath(clientsFilePath, clientContents)

	// ensure the provider directory exists
	providerDirectory := fmt.Sprintf("%s/internal/provider", input.RootDirectory)
	_ = os.MkdirAll(providerDirectory, 0755)

	// Generate the Services Registration file
	servicesRegistrationFilePath := fmt.Sprintf("%s/services_gen.go", providerDirectory)
	_ = os.Remove(servicesRegistrationFilePath)
	servicesRegistrationCode := codeForServicesRegistration(input)
	helpers.WriteToPath(servicesRegistrationFilePath, servicesRegistrationCode)

	return nil
}
