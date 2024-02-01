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

var _ cli.Command = &OutputResourceIdSegmentsCommand{}

type OutputResourceIdSegmentsCommand struct {
	logger hclog.Logger
}

func NewOutputResourceIdSegmentsCommand() func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &OutputResourceIdSegmentsCommand{
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
	includeNestedChangesWhenNew := true // needed to detect any Resource ID Segments containing Static Identifiers
	result, err := differ.Diff(a.dataApiBinaryPath, a.initialApiDefinitionsPath, a.updatedApiDefinitionsPath, includeNestedChangesWhenNew)
	if err != nil {
		c.logger.Error(fmt.Sprintf("performing diff: %+v", err))
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

func (OutputResourceIdSegmentsCommand) Synopsis() string {
	return "Determines the new Resource IDs and then outputs a unique, sorted list of Static Identifiers found in the Resource ID Segments for review."
}
