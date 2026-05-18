// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"os"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-agent-docs/generator"
	"github.com/mitchellh/cli"
)

type generateCommand struct {
	sourceDataType sdkModels.SourceDataType
}

// NewGenerateCommand returns a cli.CommandFactory used to generate agent documentation.
func NewGenerateCommand(sourceDataType sdkModels.SourceDataType) cli.CommandFactory {
	return func() (cli.Command, error) {
		return &generateCommand{
			sourceDataType: sourceDataType,
		}, nil
	}
}

func (c *generateCommand) Help() string {
	return `
Usage: generator-agent-docs <source-data-type> generate [args]

  Generates Markdown documentation for AI agents based on the API Definitions.

Arguments:
  --api-definitions-dir   The path to the API Definitions directory. Defaults to '../../api-definitions'.
  --output-dir            The output directory for the generated markdown. Defaults to '../../agent-definitions'.
`
}

func (c *generateCommand) Run(args []string) int {
	logger := hclog.Default()

	apiDefinitionsDir := "../../api-definitions"
	outputDir := "../../agent-definitions"
	var limitTo []string

	// Very simple arg parsing for now
	for i := 0; i < len(args); i++ {
		if args[i] == "--api-definitions-dir" && i+1 < len(args) {
			apiDefinitionsDir = args[i+1]
			i++
		} else if args[i] == "--output-dir" && i+1 < len(args) {
			outputDir = args[i+1]
			i++
		} else if args[i] == "--limit-to" && i+1 < len(args) {
			limitTo = append(limitTo, args[i+1])
			i++
		}
	}

	opts := generator.GenerateOptions{
		APIDefinitionsDirectory: apiDefinitionsDir,
		SourceDataType:          c.sourceDataType,
		ServiceNamesToLimitTo:   limitTo,
		Logger:                  logger,
	}

	logger.Info("Starting generation...")
	results, err := generator.Generate(opts)
	if err != nil {
		logger.Error("Failed to generate documentation", "error", err)
		return 1
	}

	logger.Info("Writing output files", "count", len(results))
	for path, res := range results {
		fullPath := filepath.Join(outputDir, path)
		dir := filepath.Dir(fullPath)

		if err := os.MkdirAll(dir, os.ModePerm); err != nil {
			logger.Error("Failed to create directory", "path", dir, "error", err)
			return 1
		}

		if err := os.WriteFile(fullPath, []byte(res.Markdown), 0644); err != nil {
			logger.Error("Failed to write file", "path", fullPath, "error", err)
			return 1
		}
	}

	logger.Info("Generation complete!")
	return 0
}

func (c *generateCommand) Synopsis() string {
	return "Generates Markdown documentation for AI agents."
}
