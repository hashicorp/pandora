package commands

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/differ"
	internalLog "github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/views"

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

	if a.outputFilePath != nil {
		c.logger.Info(fmt.Sprintf("Output will be rendered to the file located at: %q", *a.outputFilePath))
	} else {
		c.logger.Info("Output will be rendered to the console since no output file was specified")
	}

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

	// Finally determine how to output that
	if a.outputFilePath != nil {
		c.logger.Trace(fmt.Sprintf("Writing output to %q..", *a.outputFilePath))
		if err := os.WriteFile(*a.outputFilePath, []byte(*rendered), 0644); err != nil {
			c.logger.Error(fmt.Sprintf("writing output to %q: %+v", *a.outputFilePath, err))
		}
	} else {
		c.logger.Trace("Rendering output to Terminal since no output file was specified..")
		log.Print(*rendered)
	}

	return 0
}

func (DetectChangesCommand) Synopsis() string {
	return "Detects any changes between the existing and updated set of API Definitions"
}
