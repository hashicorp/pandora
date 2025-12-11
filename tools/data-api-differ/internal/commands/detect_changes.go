// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commands

import (
	"context"
	"fmt"
	"log"
	"os"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/differ"
	internalLog "github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/views"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/mitchellh/cli"
)

var _ cli.Command = &DetectChangesCommand{}

type DetectChangesCommand struct {
	logger         hclog.Logger
	sourceDataType models.SourceDataType
}

func NewDetectChangesCommand(sourceDataType models.SourceDataType) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &DetectChangesCommand{
			logger:         internalLog.Logger,
			sourceDataType: sourceDataType,
		}, nil
	}
}

func (DetectChangesCommand) Help() string {
	sourceDataTypes := make([]string, 0)
	for _, item := range v1.AvailableSourceDataTypes() {
		sourceDataTypes = append(sourceDataTypes, fmt.Sprintf("* %s", string(item)))
	}
	return fmt.Sprintf(`data-api-differ {source-data-type} detect-changes

Where '{source-data-type}' is one of:

%s

This command detects any changes that exist between the existing and an updated set of API Definitions - output as a report.

This includes both breaking and non-breaking changes.
`, strings.Join(sourceDataTypes, "\n"))
}

func (c DetectChangesCommand) Run(args []string) int {
	c.logger.Info("Running `detect-changes` command..")
	ctx := context.Background()

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
	includeNestedChangesWhenNew := false // TODO: expose this as a `--full` flag
	result, err := differ.Diff(ctx, a.dataApiBinaryPath, a.initialApiDefinitionsPath, a.updatedApiDefinitionsPath, c.sourceDataType, includeNestedChangesWhenNew)
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
