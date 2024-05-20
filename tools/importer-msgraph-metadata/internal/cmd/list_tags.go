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
	return fmt.Sprintf(`Parses Microsoft Graph API metadata and outputs the supported services by tag`)
}

func (c ListTagsCommand) Run(args []string) int {
	f := flag.NewFlagSet("importer-msgraph", flag.ExitOnError)
	f.Parse(args)

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

		MetadataDirectory:  c.metadataDirectory,
		OpenApiFilePattern: c.openApiFilePattern,
	}
	if err := pipeline.OutputSupportedServices(input); err != nil {
		log.Fatalf("Error: %+v", err)
	}

	return 0
}
