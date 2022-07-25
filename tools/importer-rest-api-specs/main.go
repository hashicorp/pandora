package main

import (
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cmd"

	"github.com/mitchellh/cli"
)

const (
	outputDirectory          = "../../data/"
	swaggerDirectory         = "../../swagger"
	resourceManagerConfig    = "../../config/resource-manager.hcl"
	terraformDefinitionsPath = "../../config/resources/"
)

func main() {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	c := cli.NewCLI("importer-rest-api-specs", "1.0.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"import":   cmd.NewImportCommand(swaggerDirectory, resourceManagerConfig, terraformDefinitionsPath, outputDirectory),
		"segments": cmd.NewSegmentsCommand(swaggerDirectory, resourceManagerConfig, terraformDefinitionsPath),
		"validate": cmd.NewValidateCommand(swaggerDirectory, resourceManagerConfig, terraformDefinitionsPath),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
