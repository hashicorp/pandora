package commands

import (
	"log"

	"github.com/mitchellh/cli"
)

var _ cli.Command = &OutputNewResourceIdSegmentsCommand{}

type OutputNewResourceIdSegmentsCommand struct {
	dataApiBinaryPath           string
	pathToInitialApiDefinitions string
	pathToUpdatedApiDefinitions string
}

func NewOutputNewResourceIdSegmentsCommand(dataApiBinaryPath, initialPath, updatedPath string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &OutputNewResourceIdSegmentsCommand{
			dataApiBinaryPath:           dataApiBinaryPath,
			pathToInitialApiDefinitions: initialPath,
			pathToUpdatedApiDefinitions: updatedPath,
		}, nil
	}
}

func (OutputNewResourceIdSegmentsCommand) Help() string {
	return `data-api-differ output-new-resource-id-segments

This command detects any new Resource IDs have been added between the existing and updated set of API Definitions and
then outputs a unique, sorted list of Resource ID Segments for review.
`
}

func (OutputNewResourceIdSegmentsCommand) Run(args []string) int {
	//TODO: implement me
	log.Printf("TODO: Implement me")
	return 0
}

func (OutputNewResourceIdSegmentsCommand) Synopsis() string {
	return "Determines the new Resource IDs and then outputs a unique, sorted list of Segments for review."
}
