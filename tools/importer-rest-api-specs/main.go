// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"log"
	"os"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/cmd"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/mitchellh/cli"
)

const (
	outputDirectoryJson                 = "../../api-definitions"
	restAPISpecsRepositoryDirectoryPath = "../../submodules/rest-api-specs"
	resourceManagerConfig               = "../../config/resource-manager.hcl"
	terraformDefinitionsPath            = "../../config/resources/"
)

func main() {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	if err := run(); err != nil {
		log.Fatal(err.Error())
	}
}

func run() error {
	loggingOpts := hclog.DefaultOptions
	if v := os.Getenv("LOG_LEVEL"); v != "" {
		loggingOpts.Level = hclog.LevelFromString(v)
	}
	logging.Log = hclog.New(loggingOpts)

	c := cli.NewCLI("importer-rest-api-specs", "1.0.0")
	c.Args = os.Args[1:]
	c.Commands = map[string]cli.CommandFactory{
		"import":   cmd.NewImportCommand(restAPISpecsRepositoryDirectoryPath, resourceManagerConfig, terraformDefinitionsPath, outputDirectoryJson),
		"validate": cmd.NewValidateCommand(restAPISpecsRepositoryDirectoryPath, resourceManagerConfig, terraformDefinitionsPath),
	}

	exitStatus, err := c.Run()
	if err != nil {
		log.Println(err)
	}

	os.Exit(exitStatus)
	return nil
}
