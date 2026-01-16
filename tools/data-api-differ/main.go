// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"fmt"
	"os"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/commands"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
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

	// determine the Source Data Type
	args := os.Args[1:]
	sourceDataType, err := parseSourceDataType(args)
	if err != nil {
		return err
	}

	// then trim it off the front
	args = args[1:]

	c := cli.NewCLI(binaryName, "1.0.0")
	c.Args = args
	c.Commands = map[string]cli.CommandFactory{
		"detect-breaking-changes":     commands.NewDetectBreakingChangesCommand(*sourceDataType),
		"detect-changes":              commands.NewDetectChangesCommand(*sourceDataType),
		"output-resource-id-segments": commands.NewOutputResourceIdSegmentsCommand(*sourceDataType),
	}

	exitStatus, err := c.Run()
	if err != nil {
		return err
	}

	os.Exit(exitStatus)
	return nil
}

func parseSourceDataType(args []string) (*models.SourceDataType, error) {
	if len(args) == 0 {
		return nil, fmt.Errorf("a source data type should be specified as the first argument e.g. `%s`", models.ResourceManagerSourceDataType)
	}
	rawVal := args[0]
	for _, dataType := range v1.AvailableSourceDataTypes() {
		if rawVal == string(dataType) {
			return pointer.To(dataType), nil
		}
	}

	return nil, fmt.Errorf("expected a source data type matching [%+v] but got %q", v1.AvailableSourceDataTypes(), rawVal)
}
