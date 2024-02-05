// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"os"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/commands"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/mitchellh/cli"
)

const binaryName = "data-api-differ"

func main() {
	opts := hclog.DefaultOptions
	opts.Level = hclog.Info
	if level := os.Getenv("LOG_LEVEL"); level != "" {
		opts.Level = hclog.LevelFromString(level)
	}
	log.Logger = hclog.New(opts)

	if err := run(); err != nil {
		log.Logger.Error(err.Error())
		os.Exit(1)
	}
}

func run() error {
	log.Logger.Info("Data API Differ launched..")

	c := cli.NewCLI(binaryName, "1.0.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"detect-breaking-changes":     commands.NewDetectBreakingChangesCommand(),
		"detect-changes":              commands.NewDetectChangesCommand(),
		"output-resource-id-segments": commands.NewOutputResourceIdSegmentsCommand(),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Logger.Error(err.Error())
	}

	os.Exit(exitStatus)
	return nil
}
