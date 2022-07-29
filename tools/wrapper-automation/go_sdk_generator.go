package main

import (
	"flag"
	"log"

	"github.com/mitchellh/cli"
)

var _ cli.Command = GoSdkGeneratorCmd{}

type GoSdkGeneratorCmd struct {
}

func (c GoSdkGeneratorCmd) Help() string {
	return "Launches the Data API, waits for it to become available and then runs the Go SDK Generator."
}

func (c GoSdkGeneratorCmd) Run(args []string) int {
	arguments := Arguments{
		DataApiPort:       5000,
		RunGoSdkGenerator: true,
	}

	f := flag.NewFlagSet("wrapper-automation", flag.ExitOnError)
	f.StringVar(&arguments.DataApiAssemblyPath, "data-api-assembly-path", "", "-data-api-assembly-path=../data/Pandora.Api.dll")
	f.StringVar(&arguments.OutputDirectory, "output-dir", "", "-output-dir=../output")

	if err := f.Parse(args); err != nil {
		log.Fatalf("parsing arguments: %+v", err)
		return 1
	}

	if err := run(arguments); err != nil {
		log.Fatalf("running: %+v", err)
		return 1
	}

	return 0
}

func (c GoSdkGeneratorCmd) Synopsis() string {
	return "runs the Go SDK Generator with a connection to the Data API"
}
