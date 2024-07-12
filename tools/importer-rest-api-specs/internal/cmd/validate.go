// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"log"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/pipeline"
	"github.com/mitchellh/cli"
)

func NewValidateCommand(restAPISpecsRepositoryDirectoryPath, resourceManagerConfigPath, terraformDefinitionsPath string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ValidateCommand{
			resourceManagerConfigPath:           resourceManagerConfigPath,
			restAPISpecsRepositoryDirectoryPath: restAPISpecsRepositoryDirectoryPath,
			terraformDefinitionsPath:            terraformDefinitionsPath,
		}, nil
	}
}

var _ cli.Command = ValidateCommand{}

type ValidateCommand struct {
	resourceManagerConfigPath           string
	restAPISpecsRepositoryDirectoryPath string
	terraformDefinitionsPath            string
}

func (ValidateCommand) Help() string {
	return "Validates that the data within the './submodules/rest-api-specs' submodule can be parsed"
}

func (c ValidateCommand) Run(args []string) int {
	opts := pipeline.Options{
		APIDefinitionsDirectory:       "", // not used for this
		ConfigFilePath:                c.resourceManagerConfigPath,
		ProviderPrefix:                "azurerm",
		RestAPISpecsDirectory:         c.restAPISpecsRepositoryDirectoryPath,
		ServiceNamesToLimitTo:         nil, // not used for this
		SourceDataOrigin:              sdkModels.AzureRestAPISpecsSourceDataOrigin,
		SourceDataType:                sdkModels.ResourceManagerSourceDataType,
		TerraformDefinitionsDirectory: c.terraformDefinitionsPath,
	}
	if err := pipeline.RunValidate(opts); err != nil {
		log.Printf("Error: %+v", err)
		return 1
	}

	return 0
}

func (ValidateCommand) Synopsis() string {
	return "Validates that the data within the './submodules/rest-api-specs' submodule can be parsed"
}
