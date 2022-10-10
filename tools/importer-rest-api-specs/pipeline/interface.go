package pipeline

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

type RunInput struct {
	ConfigFilePath           string
	DataApiEndpoint          *string
	JustOutputSegments       bool
	JustParseData            bool
	Logger                   hclog.Logger
	OutputDirectory          string
	ProviderPrefix           string
	Services                 []string
	SwaggerDirectory         string
	TerraformDefinitionsPath string
}

func Run(input RunInput) error {
	logger := hclog.New(hclog.DefaultOptions)
	resources, err := definitions.LoadFromDirectory(input.TerraformDefinitionsPath)
	if err != nil {
		return fmt.Errorf("loading terraform definitions from %q: %+v", input.TerraformDefinitionsPath, err)
	}

	findInput := discovery.FindServiceInput{
		SwaggerDirectory: input.SwaggerDirectory,
		ConfigFilePath:   input.ConfigFilePath,
		OutputDirectory:  input.OutputDirectory,
		Logger:           input.Logger.Named("Discovery"),
	}

	var generationData *[]discovery.ServiceInput

	if len(input.Services) > 0 {
		logger.Info(fmt.Sprintf("Finding only the Services %q", strings.Join(input.Services, ", ")))
		generationData, err = discovery.FindServicesByName(findInput, *resources, input.Services)
	} else {
		logger.Info("Finding all services.. this may take a while..")
		generationData, err = discovery.FindServices(findInput, *resources)
	}

	if err != nil {
		return fmt.Errorf("loading data: %+v", err)
	}

	swaggerGitSha, err := determineGitSha(input.SwaggerDirectory, input.Logger)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", input.SwaggerDirectory, err)
	}

	if input.JustOutputSegments {
		return parseAndOutputSegments(input, *generationData)
	}

	if input.JustParseData {
		return validateCanParseData(input, *generationData)
	}

	return runImporter(input, *generationData, *swaggerGitSha)
}
