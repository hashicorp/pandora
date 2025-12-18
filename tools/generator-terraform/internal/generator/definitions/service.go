// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package definitions

import (
	"fmt"
	"os"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/helpers"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func ForService(input models.ServiceInput) error {
	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	_ = os.MkdirAll(serviceDirectory, 0755)

	// ensure the Client directory exists
	serviceClientDirectory := fmt.Sprintf("%s/client", serviceDirectory)
	_ = os.MkdirAll(serviceClientDirectory, 0755)

	// Generate the Client for this Service Package
	clientFilePath := fmt.Sprintf("%s/client_gen.go", serviceClientDirectory)
	_ = os.Remove(clientFilePath)
	clientContents := templateForServiceClient(input)
	helpers.WriteToPath(clientFilePath, clientContents)

	// Generate the Registration for this Service Package
	registrationFilePath := fmt.Sprintf("%s/registration_gen.go", serviceDirectory)
	_ = os.Remove(registrationFilePath)
	registrationContents := templateForServiceRegistration(input)
	helpers.WriteToPath(registrationFilePath, registrationContents)

	// if the manual Registration doesn't exist, write it out
	manualRegistrationFilePath := fmt.Sprintf("%s/registration.go", serviceDirectory)
	if _, err := os.ReadFile(manualRegistrationFilePath); err != nil && os.IsNotExist(err) {
		manualRegistration := codeForManualServiceRegistration(input)
		helpers.WriteToPath(manualRegistrationFilePath, manualRegistration)
	}

	return nil
}
