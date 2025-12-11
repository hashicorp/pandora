// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"flag"
	"log"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/supported-services"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ListTagsCommand{}

func NewListTagsCommand(metadataDirectory, openApiFilePattern string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ListTagsCommand{
			metadataDirectory:  metadataDirectory,
			openApiFilePattern: openApiFilePattern,
		}, nil
	}
}

type ListTagsCommand struct {
	metadataDirectory  string
	openApiFilePattern string
}

func (ListTagsCommand) Synopsis() string {
	return "Parses Microsoft Graph API metadata and outputs the supported services by tag"
}

func (ListTagsCommand) Help() string {
	return "Parses Microsoft Graph API metadata and outputs the supported services by tag"
}

func (c ListTagsCommand) Run(args []string) int {
	f := flag.NewFlagSet("importer-msgraph", flag.ExitOnError)

	if err := f.Parse(args); err != nil {
		log.Fatalf("Error: %+v", err)
	}

	input := supported_services.SupportedServicesInput{
		Logger:             logging.Log,
		MetadataDirectory:  c.metadataDirectory,
		OpenApiFilePattern: c.openApiFilePattern,
	}
	if err := supported_services.OutputSupportedServices(input); err != nil {
		log.Fatalf("Error: %+v", err)
	}

	return 0
}
