package main

import (
	"github.com/hashicorp/pandora/tools/importer-msgraph/cmd"
	"github.com/mitchellh/cli"
	"log"
	"os"
)

const (
	metadataDirectory = "../../msgraph-metadata"
	openApiFile       = "transformed_v1.0_metadata.xml.yaml"
)

func main() {
	c := cli.NewCLI("importer-msgraph", "0.1.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"import": cmd.NewImportCommand(metadataDirectory, openApiFile),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
