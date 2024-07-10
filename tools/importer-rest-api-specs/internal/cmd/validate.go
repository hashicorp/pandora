// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	legacyPipeline "github.com/hashicorp/pandora/tools/importer-rest-api-specs/pipeline"
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
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
	// TODO: can't enable this until the Parser is refactored
	//opts := pipeline.Options{
	//	APIDefinitionsDirectory:       "", // not used for this
	//	ConfigFilePath:                c.resourceManagerConfigPath,
	//	ProviderPrefix:                "azurerm",
	//	RestAPISpecsDirectory:         c.restAPISpecsRepositoryDirectoryPath,
	//	ServiceNamesToLimitTo:         nil, // not used for this
	//	SourceDataOrigin:              sdkModels.AzureRestAPISpecsSourceDataOrigin,
	//	SourceDataType:                sdkModels.ResourceManagerSourceDataType,
	//	TerraformDefinitionsDirectory: c.terraformDefinitionsPath,
	//}
	//if err := pipeline.RunValidate(opts); err != nil {
	//	log.Printf("Error: %+v", err)
	//	return 1
	//}
	//
	//return 0

	input := legacyPipeline.RunInput{
		ConfigFilePath:           c.resourceManagerConfigPath,
		JustParseData:            true,
		Logger:                   logging.Log,
		OutputDirectory:          os.DevNull,
		ProviderPrefix:           "azurerm",
		SwaggerDirectory:         c.restAPISpecsRepositoryDirectoryPath,
		TerraformDefinitionsPath: c.terraformDefinitionsPath,
	}
	if err := legacyPipeline.Run(input); err != nil {
		log.Printf("Error: %+v", err)
		return 1
	}

	return 0
}

func (ValidateCommand) Synopsis() string {
	return "Validates that the data within the './submodules/rest-api-specs' submodule can be parsed"
}
