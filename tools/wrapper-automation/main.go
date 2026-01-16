// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/wrapper-automation/internal/cmds"
	"github.com/mitchellh/cli"
)

func main() {
	logOpts := hclog.DefaultOptions
	if v := os.Getenv("LOG_LEVEL"); v != "" {
		logOpts.Level = hclog.LevelFromString(v)
	}

	args := os.Args[1:]
	sourceDataType, err := parseSourceDataType(args)
	if err != nil {
		log.Fatal(err.Error())
	}
	args = args[1:]

	c := cli.NewCLI("wrapper-automation", "1.0.0")
	c.Args = args
	c.Commands = map[string]cli.CommandFactory{
		"go-sdk":    cmds.NewGoSDKGeneratorCommand(*sourceDataType, logOpts),
		"terraform": cmds.NewTerraformGeneratorCommand(*sourceDataType, logOpts),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Fatal(err.Error())
	}

	os.Exit(exitStatus)
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
