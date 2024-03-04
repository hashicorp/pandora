// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/pipeline"
	"github.com/mitchellh/cli"
)

func NewValidateCommand(swaggerDirectory, resourceManagerConfigPath, terraformDefinitionsPath string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ValidateCommand{
			resourceManagerConfigPath: resourceManagerConfigPath,
			terraformDefinitionsPath:  terraformDefinitionsPath,
			swaggerDirectory:          swaggerDirectory,
		}, nil
	}
}

var _ cli.Command = ValidateCommand{}

type ValidateCommand struct {
	resourceManagerConfigPath string
	terraformDefinitionsPath  string
	swaggerDirectory          string
}

func (ValidateCommand) Help() string {
	return "Validates that the data within the './submodules/rest-api-specs' submodule can be parsed"
}

func (c ValidateCommand) Run(args []string) int {
	input := pipeline.RunInput{
		ConfigFilePath:           c.resourceManagerConfigPath,
		JustParseData:            true,
		Logger:                   logging.Log,
		OutputDirectory:          os.DevNull,
		ProviderPrefix:           "azurerm",
		SwaggerDirectory:         c.swaggerDirectory,
		TerraformDefinitionsPath: c.terraformDefinitionsPath,
	}
	if err := pipeline.Run(input); err != nil {
		log.Printf("Error: %+v", err)
		return 1
	}

	return 0
}

func (ValidateCommand) Synopsis() string {
	return "Validates that the data within the './submodules/rest-api-specs' submodule can be parsed"
}
