// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"flag"
	"fmt"
	"log"
	"os"
	"strings"
	"time"

	"github.com/hashicorp/go-hclog"
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
	return fmt.Sprintf(`Imports and parses Microsoft Graph API metadata`)
}

func (c ImportCommand) Run(args []string) int {
	var serviceNamesRaw string

	f := flag.NewFlagSet("importer-msgraph", flag.ExitOnError)
	f.StringVar(&serviceNamesRaw, "services", "", "A list of comma separated Service named from the Data API to import")
	f.Parse(args)

	var serviceNames []string
	if serviceNamesRaw != "" {
		serviceNames = strings.Split(serviceNamesRaw, ",")
	}

	logger := hclog.New(&hclog.LoggerOptions{
		Level:  hclog.DefaultLevel,
		Output: hclog.DefaultOutput,
		TimeFn: time.Now,
	})

	if logLevel := strings.TrimSpace(os.Getenv("PANDORA_LOG")); logLevel != "" {
		logger.SetLevel(hclog.LevelFromString(logLevel))
	}

	input := pipeline.RunInput{
		ProviderPrefix: "azuread",
		Logger:         logger,

		ConfigFilePath:     c.microsoftGraphConfigPath,
		MetadataDirectory:  c.metadataDirectory,
		OpenApiFilePattern: c.openApiFilePattern,
		OutputDirectory:    c.outputDirectory,
		Services:           serviceNames,
	}
	if err := pipeline.Run(input); err != nil {
		log.Fatalf("Error: %+v", err)
	}

	return 0
}
