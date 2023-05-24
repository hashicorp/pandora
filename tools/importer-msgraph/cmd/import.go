package cmd

import (
	"flag"
	"fmt"
	"log"
	"os"
	"strings"
	"time"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-msgraph/pipeline"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ImportCommand{}

func NewImportCommand(metadataDirectory, openApiFile, terraformDefinitionsPath, outputDirectory string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ImportCommand{
			metadataDirectory:        metadataDirectory,
			openApiFile:              openApiFile,
			outputDirectory:          outputDirectory,
			terraformDefinitionsPath: terraformDefinitionsPath,
		}, nil
	}
}

type ImportCommand struct {
	metadataDirectory        string
	openApiFile              string
	outputDirectory          string
	terraformDefinitionsPath string
}

func (ImportCommand) Synopsis() string {
	return "Imports Microsoft Graph API metadata and outputs HCL data definitions"
}

func (ImportCommand) Help() string {
	return fmt.Sprintf(`Imports and parses Microsoft Graph API metadata
Arguments:

-tags=applications,servicePrincipals'
        Specifies a comma-separated list of services to import, rather than the entire API.
`)
}

func (c ImportCommand) Run(args []string) int {
	var tagsRaw string

	f := flag.NewFlagSet("importer-msgraph", flag.ExitOnError)
	f.StringVar(&tagsRaw, "tags", "", "A list of comma separated tags to import")
	f.Parse(args)

	var tags []string
	if tagsRaw != "" {
		tags = strings.Split(tagsRaw, ",")
	}

	logger := hclog.New(&hclog.LoggerOptions{
		Level:  hclog.DefaultLevel,
		Output: hclog.DefaultOutput,
		TimeFn: time.Now,
	})

	if strings.TrimSpace(os.Getenv("DEBUG")) != "" {
		logger.SetLevel(hclog.Trace)
	}

	input := pipeline.RunInput{
		Logger: logger,

		MetadataDirectory:        c.metadataDirectory,
		OpenApiFile:              c.openApiFile,
		OutputDirectory:          c.outputDirectory,
		ProviderPrefix:           "azuread",
		Tags:                     tags,
		TerraformDefinitionsPath: c.terraformDefinitionsPath,
	}
	if err := pipeline.Run(input); err != nil {
		log.Printf("Error: %+v", err)
		return 1
	}

	return 0
}
