// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"log"
	"os"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/cmd"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
	"github.com/mitchellh/cli"
)

const (
	metadataDirectory    = "../../submodules/msgraph-metadata"
	microsoftGraphConfig = "../../config/microsoft-graph.hcl"
	openApiFilePattern   = "openapi/%s/default.yaml"
	outputDirectory      = "../../api-definitions"
)

func main() {
	loggingOpts := hclog.DefaultOptions
	if v := os.Getenv("LOG_LEVEL"); v != "" {
		loggingOpts.Level = hclog.LevelFromString(v)
	}
	logging.Log = hclog.New(loggingOpts)

	c := cli.NewCLI("importer-msgraph-metadata", "0.3.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"import":    cmd.NewImportCommand(metadataDirectory, microsoftGraphConfig, openApiFilePattern, outputDirectory),
		"list-tags": cmd.NewListTagsCommand(metadataDirectory, openApiFilePattern),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
