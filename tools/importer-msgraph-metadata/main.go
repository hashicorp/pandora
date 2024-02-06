// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/cmd"
	"github.com/mitchellh/cli"
)

const (
	commonTypesDirectoryName = "CommonTypes"
	metadataDirectory        = "../../submodules/msgraph-metadata"
	microsoftGraphConfig     = "../../config/microsoft-graph.hcl"
	openApiFilePattern       = "transformed_%s_metadata.xml.yaml"
	outputDirectory          = "../../data"
)

var supportedVersions = []string{"v1.0", "beta"}

func main() {
	c := cli.NewCLI("importer-msgraph-metadata", "0.1.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"import":    cmd.NewImportCommand(metadataDirectory, microsoftGraphConfig, openApiFilePattern, outputDirectory, commonTypesDirectoryName, supportedVersions),
		"list-tags": cmd.NewListTagsCommand(metadataDirectory, openApiFilePattern, supportedVersions),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
