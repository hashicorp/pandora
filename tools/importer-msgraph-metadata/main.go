// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/cmd"
	"github.com/mitchellh/cli"
)

const (
	metadataDirectory    = "../../submodules/msgraph-metadata"
	microsoftGraphConfig = "../../config/microsoft-graph.hcl"
	openApiFilePattern   = "transformed_%s_metadata.xml.yaml"
	outputDirectory      = "../../api-definitions"
)

func main() {
	c := cli.NewCLI("importer-msgraph-metadata", "0.2.0")
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
