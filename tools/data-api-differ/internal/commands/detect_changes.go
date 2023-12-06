package commands

import (
	"log"

	"github.com/mitchellh/cli"
)

var _ cli.Command = &DetectChangesCommand{}

type DetectChangesCommand struct {
	dataApiBinaryPath           string
	pathToInitialApiDefinitions string
	pathToUpdatedApiDefinitions string
}

func NewDetectChangesCommand(dataApiBinaryPath, initialPath, updatedPath string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &DetectChangesCommand{
			dataApiBinaryPath:           dataApiBinaryPath,
			pathToInitialApiDefinitions: initialPath,
			pathToUpdatedApiDefinitions: updatedPath,
		}, nil
	}
}

func (DetectChangesCommand) Help() string {
	return `data-api-differ detect-changes

This command detects any changes that exist between the existing and an updated set of API Definitions - output as a report.

This includes both breaking and non-breaking changes.
`
}

func (DetectChangesCommand) Run(args []string) int {
	//TODO: implement me
	log.Printf("TODO: Implement me")
	return 0
}

func (DetectChangesCommand) Synopsis() string {
	return "Detects any changes between the existing and updated set of API Definitions"
}
