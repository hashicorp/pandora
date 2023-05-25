package main

import (
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/importer-msgraph/cmd"
	"github.com/mitchellh/cli"
)

const (
	metadataDirectory        = "../../msgraph-metadata"
	openApiFilePattern       = "transformed_%s_metadata.xml.yaml"
	outputDirectory          = "../../data/"
	terraformDefinitionsPath = "../../config/resources/"
)

func main() {
	c := cli.NewCLI("importer-msgraph", "0.1.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"import": cmd.NewImportCommand(metadataDirectory, openApiFilePattern, terraformDefinitionsPath, outputDirectory),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
