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

var _ cli.Command = &DetectBreakingChangesCommand{}

type DetectBreakingChangesCommand struct {
	logger hclog.Logger
}

func NewDetectBreakingChangesCommand() func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &DetectBreakingChangesCommand{
			logger: internalLog.Logger,
		}, nil
	}
}

func (DetectBreakingChangesCommand) Help() string {
	return `data-api-differ detect-breaking-changes

This command detects any breaking changes that exist between the existing and an updated set of API Definitions - output as a report.
`
}

func (c DetectBreakingChangesCommand) Run(args []string) int {
	c.logger.Info("Running `detect-breaking-changes` command..")

	a := arguments{}
	c.logger.Debug("Parsing arguments..")
	if err := a.parse(args); err != nil {
		c.logger.Error(fmt.Sprintf("parsing arguments: %+v", err))
		return 1
	}

	if err := a.validate(); err != nil {
		c.logger.Error(fmt.Sprintf("validating arguments: %+v", err))
		return 1
	}

	c.logger.Info(fmt.Sprintf("Data API Binary located at %q", a.dataApiBinaryPath))
	c.logger.Info(fmt.Sprintf("Initial API Definitions located at: %q", a.initialApiDefinitionsPath))
	c.logger.Info(fmt.Sprintf("Updated API Definitions located at: %q", a.updatedApiDefinitionsPath))

	c.logger.Debug("Performing diff of the two data sources..")
	result, err := differ.Diff(a.dataApiBinaryPath, a.initialApiDefinitionsPath, a.updatedApiDefinitionsPath)
	if err != nil {
		c.logger.Error(fmt.Sprintf("performing diff: %+v", err))
		return 1
	}

	// then render the output
	c.logger.Debug("Rendering the Breaking Changes..")
	view := views.NewBreakingChangesView(result.Changes)
	rendered, err := view.RenderMarkdown()
	if err != nil {
		c.logger.Error(fmt.Sprintf("rendering markdown: %+v", err))
		return 1
	}
	log.Print(*rendered)

	return 0
}

func (DetectBreakingChangesCommand) Synopsis() string {
	return "Retrieves two sets of API Definitions from the Data API and determines if there are any breaking changes"
}
