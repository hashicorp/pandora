// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"log"
	"os"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api/internal/commands"
	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
	"github.com/mitchellh/cli"
)

func main() {
	loggingOpts := hclog.DefaultOptions
	if v := os.Getenv("LOG_LEVEL"); v != "" {
		loggingOpts.Level = hclog.LevelFromString(v)
	}
	logging.Log = hclog.New(loggingOpts)
	logging.Info("Data API launched..")

	c := cli.NewCLI("data-api", "1.0.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"serve": commands.NewServeCommand(),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Fatal(err.Error())
	}

	os.Exit(exitStatus)
}
