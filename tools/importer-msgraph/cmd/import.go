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

func NewImportCommand(metadataDirectory, openApiFilePattern, terraformDefinitionsPath, outputDirectory string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ImportCommand{
			metadataDirectory:        metadataDirectory,
			openApiFilePattern:       openApiFilePattern,
			outputDirectory:          outputDirectory,
			terraformDefinitionsPath: terraformDefinitionsPath,
		}, nil
	}
}

type ImportCommand struct {
	metadataDirectory        string
	openApiFilePattern       string
	outputDirectory          string
	terraformDefinitionsPath string
}

func (ImportCommand) Synopsis() string {
	return "Imports Microsoft Graph API metadata and outputs HCL data definitions"
}

func (ImportCommand) Help() string {
	return fmt.Sprintf(`Imports and parses Microsoft Graph API metadata
Arguments:

-tags=applications,servicePrincipals
        Specifies a comma-separated list of services to import, rather than the entire API.

-versions=v1.0,beta
        Specified the API versions to import. Defaults to 'v1.0,beta'
`)
}

func (c ImportCommand) Run(args []string) int {
	var apiVersionsRaw, tagsRaw string

	f := flag.NewFlagSet("importer-msgraph", flag.ExitOnError)
	f.StringVar(&tagsRaw, "tags", "", "A list of comma separated tags to import")
	f.StringVar(&apiVersionsRaw, "versions", "", "A list of comma separated API versions to import")
	f.Parse(args)

	apiVersions := []string{"v1.0", "beta"}
	if apiVersionsRaw != "" {
		apiVersions = strings.Split(apiVersionsRaw, ",")
	}

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

		ApiVersions:              apiVersions,
		MetadataDirectory:        c.metadataDirectory,
		OpenApiFilePattern:       c.openApiFilePattern,
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
