package commands

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/differ"
	internalLog "github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/views"
	"log"

	"github.com/mitchellh/cli"
)

var _ cli.Command = &DetectChangesCommand{}

type DetectChangesCommand struct {
	logger hclog.Logger
}

func NewDetectChangesCommand() func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &DetectChangesCommand{
			logger: internalLog.Logger,
		}, nil
	}
}

func (DetectChangesCommand) Help() string {
	return `data-api-differ detect-changes

This command detects any changes that exist between the existing and an updated set of API Definitions - output as a report.

This includes both breaking and non-breaking changes.
`
}

func (c DetectChangesCommand) Run(args []string) int {
	c.logger.Info("Running `detect-changes` command..")

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
	c.logger.Debug("Rendering the Changes..")
	view := views.NewChangesView(result.Changes)
	rendered, err := view.RenderMarkdown()
	if err != nil {
		c.logger.Error(fmt.Sprintf("rendering markdown: %+v", err))
		return 1
	}
	log.Print(*rendered)

	return 0
}

func (DetectChangesCommand) Synopsis() string {
	return "Detects any changes between the existing and updated set of API Definitions"
}
