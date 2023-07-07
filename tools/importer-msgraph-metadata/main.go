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
	openApiFilePattern       = "transformed_%s_metadata.xml.yaml"
	outputDirectory          = "../../data"
)

func main() {
	c := cli.NewCLI("importer-msgraph-metadata", "0.1.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"import": cmd.NewImportCommand(metadataDirectory, openApiFilePattern, outputDirectory, commonTypesDirectoryName),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
