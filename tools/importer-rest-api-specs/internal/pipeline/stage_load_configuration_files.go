// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

func (p *Pipeline) loadConfigurationFiles() error {
	logging.Debug("Parsing the Configuration File..")
	servicesFromConfigurationFile, err := services.LoadFromFile(p.opts.ConfigFilePath)
	if err != nil {
		return fmt.Errorf("loading config at %q: %+v", p.opts.ConfigFilePath, err)
	}
	p.servicesFromConfigurationFiles = servicesFromConfigurationFile.Services
	logging.Debug("Completed - Parsing the Configuration File.")

	logging.Debug("Parsing the Terraform Resource Definitions..")
	terraformResourceDefinitions, err := definitions.LoadFromDirectory(p.opts.TerraformDefinitionsDirectory)
	if err != nil {
		return fmt.Errorf("parsing the Terraform Definitions from %q: %+v", p.opts.TerraformDefinitionsDirectory, err)
	}

	// NOTE: when the `definitions` package is refactored, this can be cleaned up
	// part of https://github.com/hashicorp/pandora/issues/3754
	servicesToTerraformDetails := make(map[string]terraformDetailsForService)
	for serviceName, serviceData := range terraformResourceDefinitions.Services {
		terraformResourceDefinition := make(map[string]definitions.ResourceDefinition)
		for _, apiVersionData := range serviceData.ApiVersions {
			for _, apiResourceData := range apiVersionData.Packages {
				for resourceLabel, resourceData := range apiResourceData.Definitions {
					terraformResourceDefinition[resourceLabel] = resourceData
				}
			}
		}
		servicesToTerraformDetails[serviceName] = terraformDetailsForService{
			resourceLabelToResourceDefinitions: terraformResourceDefinition,
			terraformPackageName:               pointer.To(serviceData.TerraformPackageName),
		}
	}
	p.servicesToTerraformDetails = servicesToTerraformDetails
	logging.Debug("Completed - Parsing the Terraform Resource Definitions.")
	return nil
}
