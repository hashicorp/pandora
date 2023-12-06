package commands

import (
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/mitchellh/cli"
)

var _ cli.Command = &DetectBreakingChangesCommand{}

type DetectBreakingChangesCommand struct {
	dataApiBinaryPath           string
	pathToInitialApiDefinitions string
	pathToUpdatedApiDefinitions string
}

func NewDetectBreakingChangesCommand(dataApiBinaryPath, initialPath, updatedPath string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &DetectBreakingChangesCommand{
			dataApiBinaryPath:           dataApiBinaryPath,
			pathToInitialApiDefinitions: initialPath,
			pathToUpdatedApiDefinitions: updatedPath,
		}, nil
	}
}

func (DetectBreakingChangesCommand) Help() string {
	return `data-api-differ detect-breaking-changes

This command detects any breaking changes that exist between the existing and an updated set of API Definitions - output as a report.
`
}

func (DetectBreakingChangesCommand) Run(args []string) int {
	log.Logger.Info("Running `detect-breaking-changes` command..")
	return 0
}

func (DetectBreakingChangesCommand) Synopsis() string {
	return "Retrieves two sets of API Definitions from the Data API and determines if there are any breaking changes"
}
