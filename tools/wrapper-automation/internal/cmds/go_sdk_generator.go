// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmds

import (
	"context"
	"log"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/wrapper-automation/internal/pipeline"
	"github.com/mitchellh/cli"
)

var _ cli.Command = GoSDKGenerator{}

type GoSDKGenerator struct {
	// logger is an instance of hclog intended for debug logging.
	logger hclog.Logger

	// sourceDataType specifies the Source Data Type being queried.
	sourceDataType models.SourceDataType
}

func NewGoSDKGeneratorCommand(sourceDataType models.SourceDataType, loggingOpts *hclog.LoggerOptions) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &GoSDKGenerator{
			logger:         hclog.New(loggingOpts),
			sourceDataType: sourceDataType,
		}, nil
	}
}

func (c GoSDKGenerator) Help() string {
	return "Launches the Data API, waits for it to become available and then runs the Go SDK Generator."
}

func (c GoSDKGenerator) Run(args []string) int {
	ctx := context.TODO()

	opts, err := parseCLIArguments(args)
	if err != nil {
		log.Fatal(err.Error())
	}

	pipelineOpts := pipeline.Options{
		APIDefinitionsDirectory: opts.apiDefinitionsDirectory,
		Logger:                  c.logger,
		OutputDirectory:         opts.outputDirectory,
		SourceDataType:          c.sourceDataType,
	}

	if err := pipeline.RunGoSDKGenerator(ctx, pipelineOpts); err != nil {
		log.Fatal(err.Error())
	}

	return 0
}

func (c GoSDKGenerator) Synopsis() string {
	return "runs the Go SDK Generator with a connection to the Data API"
}
