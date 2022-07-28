package main

import (
	"log"
	"os"

	"github.com/mitchellh/cli"
)

func main() {
	c := cli.NewCLI("wrapper-automation", "1.0.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"go-sdk": func() (cli.Command, error) {
			return &GoSdkGeneratorCmd{}, nil
		},
		"rest-api-specs-importer": func() (cli.Command, error) {
			return &RestApiSpecsImporterCmd{}, nil
		},
		"terraform": func() (cli.Command, error) {
			return &TerraformCmd{}, nil
		},
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
