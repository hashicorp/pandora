package commands

import (
	"fmt"
	"log"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/differ"
	internalLog "github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/views"
	"github.com/mitchellh/cli"
)

var _ cli.Command = &OutputResourceIdSegmentsCommand{}

type OutputResourceIdSegmentsCommand struct {
	dataApiBinaryPath           string
	pathToInitialApiDefinitions string
	pathToUpdatedApiDefinitions string
	logger                      hclog.Logger
}

func NewOutputResourceIdSegmentsCommand(dataApiBinaryPath, initialPath, updatedPath string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &OutputResourceIdSegmentsCommand{
			dataApiBinaryPath:           dataApiBinaryPath,
			pathToInitialApiDefinitions: initialPath,
			pathToUpdatedApiDefinitions: updatedPath,

			logger: internalLog.Logger,
		}, nil
	}
}

func (OutputResourceIdSegmentsCommand) Help() string {
	return `data-api-differ output-resource-id-segments

This command detects any new Resource IDs that have been added between the existing and updated set of API Definitions
and then outputs a unique, sorted list of any Static Identifiers found within the Resource ID Segments for review.
`
}

func (c OutputResourceIdSegmentsCommand) Run(args []string) int {
	c.logger.Info("Running `output-resource-id-segments` command..")

	c.logger.Debug("Performing diff of the two data sources..")
	result, err := differ.Diff(c.dataApiBinaryPath, c.pathToInitialApiDefinitions, c.pathToUpdatedApiDefinitions)
	if err != nil {
		c.logger.Error("performing diff: %+v", err)
		return 1
	}

	// then render the output
	c.logger.Debug("Rendering the Changes..")
	view := views.NewResourceIdSegmentsView(result.Changes)
	rendered, err := view.RenderMarkdown()
	if err != nil {
		c.logger.Error(fmt.Sprintf("rendering markdown: %+v", err))
		return 1
	}
	log.Print(*rendered)

	return 0
}

func (OutputResourceIdSegmentsCommand) Synopsis() string {
	return "Determines the new Resource IDs and then outputs a unique, sorted list of Static Identifiers found in the Resource ID Segments for review."
}
