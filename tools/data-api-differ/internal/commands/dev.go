package commands

import (
	"fmt"
	"reflect"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/differ"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/mitchellh/cli"
)

var _ cli.Command = DevCommand{}

type DevCommand struct {
	dataApiBinaryPath           string
	pathToInitialApiDefinitions string
	pathToUpdatedApiDefinitions string
}

func NewDevCommand(dataApiBinaryPath, initialPath, updatedPath string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &DevCommand{
			dataApiBinaryPath:           dataApiBinaryPath,
			pathToInitialApiDefinitions: initialPath,
			pathToUpdatedApiDefinitions: updatedPath,
		}, nil
	}
}

func (d DevCommand) Help() string {
	return "Dev Mode"
}

func (d DevCommand) Run(args []string) int {
	result, err := differ.Diff(d.dataApiBinaryPath, d.pathToInitialApiDefinitions, d.pathToUpdatedApiDefinitions)
	if err != nil {
		log.Logger.Error("performing diff: %+v", err)
		return 1
	}
	log.Logger.Info(fmt.Sprintf("Has Breaking Changes: %t", result.ContainsBreakingChanges()))
	for _, change := range result.Changes {
		log.Logger.Info(fmt.Sprintf("Change Type %q: %+v", reflect.TypeOf(change).Name(), change))
	}

	/*
		We want to output three different reports here:
			1. Breaking Changes
			2. Resource ID Segments
			3. Summary of changes

			We also need to know: if a package is being removed - is it currently vendored into `AzureRM`?
				^ this should be determinable by whether the package is vendored into the provider at which
				  point we should be able to determine from the imports whether this is required or not

		Worth outputting this in GitHub's expandable format?

		   ```
		   ## Breaking Changes

		   * Service `` API version ``

		   --

		   ## Service `MyService`
		   * New API Version: `2020-01-01`
		   ```

		In the future it'd also be nice to show the output of the updated Go SDK and Terraform Generator too, by showing
		the diff result as a GitHub comment?

	*/
	return 0
}

func (d DevCommand) Synopsis() string {
	return "Dev Mode"
}
