// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"flag"
	"log"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/pipeline"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ImportCommand{}

func NewImportDataPlaneCommand(restAPISpecsRepositoryDirectoryPath, datPlaneConfigPath, outputDirectory string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ImportDataPlaneCommand{
			outputDirectory:                     outputDirectory,
			datPlaneConfigPath:                  datPlaneConfigPath,
			restAPISpecsRepositoryDirectoryPath: restAPISpecsRepositoryDirectoryPath,
		}, nil
	}
}

type ImportDataPlaneCommand struct {
	outputDirectory                     string
	datPlaneConfigPath                  string
	restAPISpecsRepositoryDirectoryPath string
}

func (ImportDataPlaneCommand) Help() string {
	return `Import parses and processes the Data Plane Swagger Data from the './submodules/rest-api-specs' submodule.

Specify -services=Compute,Resource to limit to just that or don't for everything, you do you.
`
}

func (c ImportDataPlaneCommand) Run(args []string) int {
	var serviceNamesRaw string

	f := flag.NewFlagSet("importer-rest-api-specs", flag.ExitOnError)
	f.StringVar(&serviceNamesRaw, "services", "", "A list of comma separated Service named from the Data API to import")
	f.Parse(args)

	var serviceNames []string
	if serviceNamesRaw != "" {
		serviceNames = strings.Split(serviceNamesRaw, ",")
	}

	opts := pipeline.Options{
		APIDefinitionsDirectory: c.outputDirectory,
		ConfigFilePath:          c.datPlaneConfigPath,
		ProviderPrefix:          "azurerm",
		RestAPISpecsDirectory:   c.restAPISpecsRepositoryDirectoryPath,
		ServiceNamesToLimitTo:   serviceNames,
		SourceDataOrigin:        sdkModels.AzureRestAPISpecsSourceDataOrigin,
		SourceDataType:          sdkModels.DataPlaneSourceDataType,
	}

	if err := pipeline.RunImporter(opts); err != nil {
		log.Printf("Error: %+v", err)
		return 1
	}

	return 0
}

func (ImportDataPlaneCommand) Synopsis() string {
	return "Parses and Processes the Data from the './submodules/rest-api-specs' submodule for Data Plane APIs"
}
