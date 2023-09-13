package cmd

import (
	"fmt"
	"log"
	"os"
	"strings"
	"time"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/pipeline"
	"github.com/mitchellh/cli"
)

var _ cli.Command = SegmentsCommand{}

func NewSegmentsCommand(swaggerDirectory, resourceManagerConfigPath, terraformDefinitionsPath string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return SegmentsCommand{
			resourceManagerConfigPath: resourceManagerConfigPath,
			swaggerDirectory:          swaggerDirectory,
			terraformDefinitionsPath:  terraformDefinitionsPath,
		}, nil
	}
}

type SegmentsCommand struct {
	resourceManagerConfigPath string
	swaggerDirectory          string
	terraformDefinitionsPath  string
}

func (SegmentsCommand) Help() string {
	return fmt.Sprintf(`Outputs a list of the unique Segments used in the Resource IDs to allow for a
human to validate if any segments require recasing to match the ARM Guidelines/for consistency.
`)
}

func (c SegmentsCommand) Run(_ []string) int {
	logger := hclog.New(&hclog.LoggerOptions{
		Level:  hclog.DefaultLevel,
		Output: hclog.DefaultOutput,
		TimeFn: time.Now,
	})
	if strings.TrimSpace(os.Getenv("DEBUG")) != "" {
		logger.SetLevel(hclog.Trace)
	}
	input := pipeline.RunInput{
		ConfigFilePath:           c.resourceManagerConfigPath,
		DataApiEndpoint:          nil,
		JustOutputSegments:       true,
		Logger:                   logger,
		OutputDirectoryCS:        os.DevNull,
		OutputDirectoryYaml:      os.DevNull,
		ProviderPrefix:           "azurerm",
		SwaggerDirectory:         c.swaggerDirectory,
		TerraformDefinitionsPath: c.terraformDefinitionsPath,
	}
	if err := pipeline.Run(input); err != nil {
		log.Printf("Error: %+v", err)
		return 1
	}

	return 0
}

func (SegmentsCommand) Synopsis() string {
	return "Outputs a list of Segments used in the Resource IDs"
}
