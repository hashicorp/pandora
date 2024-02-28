// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"flag"
	"log"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/pipeline"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ImportCommand{}

func NewImportCommand(swaggerDirectory, resourceManagerConfigPath, terraformDefinitionsPath, outputDirectory string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ImportCommand{
			outputDirectory:           outputDirectory,
			resourceManagerConfigPath: resourceManagerConfigPath,
			swaggerDirectory:          swaggerDirectory,
			terraformDefinitionsPath:  terraformDefinitionsPath,
		}, nil
	}
}

type ImportCommand struct {
	outputDirectory           string
	resourceManagerConfigPath string
	swaggerDirectory          string
	terraformDefinitionsPath  string
}

func (ImportCommand) Help() string {
	return `Import parses and processes the Swagger Data from the './submodules/rest-api-specs' submodule, determining
which Terraform Data Sources & Resources can be generated - and then finally
outputs this Data in the format used by the Data API.

Specify -services=Compute,Resource to limit to just that or don't for everything, you do you.
`
}

func (c ImportCommand) Run(args []string) int {
	var serviceNamesRaw string

	f := flag.NewFlagSet("importer-rest-api-specs", flag.ExitOnError)
	f.StringVar(&serviceNamesRaw, "services", "", "A list of comma separated Service named from the Data API to import")
	f.Parse(args)

	var serviceNames []string
	if serviceNamesRaw != "" {
		serviceNames = strings.Split(serviceNamesRaw, ",")
	}

	input := pipeline.RunInput{
		ConfigFilePath:           c.resourceManagerConfigPath,
		Logger:                   logging.Log,
		OutputDirectory:          c.outputDirectory,
		ProviderPrefix:           "azurerm",
		Services:                 serviceNames,
		SwaggerDirectory:         c.swaggerDirectory,
		TerraformDefinitionsPath: c.terraformDefinitionsPath,
	}
	if err := pipeline.Run(input); err != nil {
		log.Printf("Error: %+v", err)
		return 1
	}

	return 0
}

func (ImportCommand) Synopsis() string {
	return "Parses and Processes the Data from the './submodules/rest-api-specs' submodule"
}
