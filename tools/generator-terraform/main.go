package main

import (
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/generator-terraform/cmd"
	"github.com/mitchellh/cli"
)

// TODO: split into a pipeline, logging.

func main() {
	c := cli.NewCLI("generator-terraform", "1.0.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"generate": cmd.NewGenerateCommand(),
		"mappings": cmd.NewMappingsCommand(),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
