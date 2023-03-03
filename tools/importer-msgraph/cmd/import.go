package cmd

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"strings"
	"time"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-msgraph/pipeline"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ImportCommand{}

func NewImportCommand(metadataDirectory, openApiFile string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ImportCommand{
			metadataDirectory: metadataDirectory,
			openApiFile:       openApiFile,
		}, nil
	}
}

type ImportCommand struct {
	metadataDirectory string
	openApiFile       string
}

func (ImportCommand) Synopsis() string {
	return "Imports Microsoft Graph API metadata and outputs a Go SDK"
}

func (ImportCommand) Help() string {
	return fmt.Sprintf(`Imports Microsoft Graph API metadata and outputs a Go SDK
Arguments:

-output-dir=../generated-msgraph-sdk
        Specifies the path where the generated files should be output
-tags=applications,servicePrincipals'
        Specifies a comma-separated list of tags to import, rather than the ensite API.
`)
}

func (c ImportCommand) Run(args []string) int {
	logger := hclog.New(&hclog.LoggerOptions{
		Level:  hclog.DefaultLevel,
		Output: hclog.DefaultOutput,
		TimeFn: time.Now,
	})

	input := pipeline.RunInput{
		Logger:            logger,
		MetadataDirectory: c.metadataDirectory,
		OpenApiFile:       c.openApiFile,
		Tags:              make([]string, 0),
	}

	var tagNamesRaw string

	f := flag.NewFlagSet("importer-msgraph", flag.ExitOnError)
	f.StringVar(&input.OutputDirectory, "output-dir", "", "-output-dir=../generated-sdk-dev")
	f.StringVar(&tagNamesRaw, "tags", "", "A list of comma separated tags to import")
	f.Parse(args)

	if tagNamesRaw != "" {
		input.Tags = strings.Split(tagNamesRaw, ",")
	}

	if input.OutputDirectory == "" {
		homeDir, _ := os.UserHomeDir()
		input.OutputDirectory = filepath.Join(homeDir, "/Desktop/msgraph-sdk")
	}

	if strings.TrimSpace(os.Getenv("DEBUG")) != "" {
		logger.SetLevel(hclog.Trace)
	}
	if err := pipeline.Run(input); err != nil {
		log.Printf("Error: %+v", err)
		return 1
	}

	return 0
}
