// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/cmd"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/logging"
	"github.com/mitchellh/cli"
)

func main() {
	if err := run(); err != nil {
		log.Fatal(err.Error())
	}
}

func run() error {
	// determine the Source Data Type
	args := os.Args[1:]
	sourceDataType, err := parseSourceDataType(args)
	if err != nil {
		return err
	}

	// then trim it off the front
	args = args[1:]

	loggingOpts := hclog.DefaultOptions
	if v := os.Getenv("LOG_LEVEL"); v != "" {
		loggingOpts.Level = hclog.LevelFromString(v)
	}
	logging.Log = hclog.New(loggingOpts)

	c := cli.NewCLI("generator-go-sdk", "1.0.0")
	c.Args = args
	c.Commands = map[string]cli.CommandFactory{
		"generate": cmd.NewGenerateCommand(*sourceDataType),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
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
