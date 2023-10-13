package main

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api/internal/commands"
	"github.com/mitchellh/cli"
)

const definitionsDirectory = "../../api-definitions/"

func main() {
	logger := hclog.New(hclog.DefaultOptions)
	logger.SetLevel(hclog.Trace)

	c := cli.NewCLI("data-api", "1.0.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"serve": commands.NewServeCommand(definitionsDirectory),
		// TODO hook this up
		"serve-watch": func() (cli.Command, error) {
			return nil, fmt.Errorf("TODO: implement me")
		},
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
}
