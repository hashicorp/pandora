// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"log"
	"os"
	"strings"
	"time"

	"github.com/hashicorp/go-hclog"
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
	logger := hclog.New(&hclog.LoggerOptions{
		Level:  hclog.DefaultLevel,
		Output: hclog.DefaultOutput,
		TimeFn: time.Now,
	})
	if strings.TrimSpace(os.Getenv("DEBUG")) != "" {
		logger.SetLevel(hclog.Trace)
	}

	input := pipeline.RunInput{
		ConfigFilePath:           c.resourceManagerConfigPath,
		DataApiEndpoint:          nil,
		JustParseData:            true,
		Logger:                   logger,
		OutputDirectoryCS:        os.DevNull,
		OutputDirectoryJson:      os.DevNull,
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
