// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"flag"
	"log"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/pipeline"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ImportCommand{}

func NewImportCommand(metadataDirectory, microsoftGraphConfigPath, openApiFilePattern, outputDirectory string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ImportCommand{
			metadataDirectory:        metadataDirectory,
			microsoftGraphConfigPath: microsoftGraphConfigPath,
			openApiFilePattern:       openApiFilePattern,
			outputDirectory:          outputDirectory,
		}, nil
	}
}

type ImportCommand struct {
	metadataDirectory        string
	microsoftGraphConfigPath string
	openApiFilePattern       string
	outputDirectory          string
}

func (ImportCommand) Synopsis() string {
	return "Imports Microsoft Graph API metadata and outputs this Data in the format used by the Data API"
}

func (ImportCommand) Help() string {
	return "Imports and parses Microsoft Graph API metadata"
}

func (c ImportCommand) Run(args []string) int {
	var serviceNamesRaw string

	f := flag.NewFlagSet("importer-msgraph", flag.ExitOnError)
	f.StringVar(&serviceNamesRaw, "services", "", "A list of comma separated Service named from the Data API to import")

	if err := f.Parse(args); err != nil {
		log.Fatalf("Error: %+v", err)
	}

	var serviceNames []string
	if serviceNamesRaw != "" {
		serviceNames = strings.Split(serviceNamesRaw, ",")
	}

	input := pipeline.RunInput{
		ProviderPrefix: "azuread",
		Logger:         logging.Log,

		ConfigFilePath:     c.microsoftGraphConfigPath,
		MetadataDirectory:  c.metadataDirectory,
		OpenApiFilePattern: c.openApiFilePattern,
		OutputDirectory:    c.outputDirectory,
		Repo:               repository.NewRepository(c.outputDirectory, logging.Log),
		Services:           serviceNames,
	}
	if err := pipeline.Run(input); err != nil {
		log.Fatalf("Error: %+v", err)
	}

	return 0
}
