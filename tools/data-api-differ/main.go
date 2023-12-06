package main

import (
	"os"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/commands"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/mitchellh/cli"
)

func main() {
	opts := hclog.DefaultOptions
	if level := os.Getenv("DEBUG"); level != "" {
		opts.Level = hclog.Debug
	}
	log.Logger = hclog.New(opts)

	if err := run(); err != nil {
		log.Logger.Error(err.Error())
		os.Exit(1)
	}
}

func run() error {
	log.Logger.Info("Data API Differ launched..")

	dataApiBinaryPath := "..."
	initialPath := "..."
	updatedPath := "..."

	c := cli.NewCLI("data-api-differ", "1.0.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"detect-breaking-changes":         commands.NewDetectBreakingChangesCommand(dataApiBinaryPath, initialPath, updatedPath),
		"detect-changes":                  commands.NewDetectChangesCommand(dataApiBinaryPath, initialPath, updatedPath),
		"dev":                             commands.NewDevCommand(dataApiBinaryPath, initialPath, updatedPath),
		"output-new-resource-id-segments": commands.NewOutputNewResourceIdSegmentsCommand(dataApiBinaryPath, initialPath, updatedPath),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Logger.Error(err.Error())
	}

	os.Exit(exitStatus)
	return nil
}
