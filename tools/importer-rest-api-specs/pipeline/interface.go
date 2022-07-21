package pipeline

import "github.com/hashicorp/go-hclog"

type RunInput struct {
	ConfigFilePath           string
	DataApiEndpoint          *string
	JustOutputSegments       bool
	JustParseData            bool
	Logger                   hclog.Logger
	OutputDirectory          string
	SwaggerDirectory         string
	TerraformDefinitionsPath string
}

func Run(input RunInput) error {
	if input.JustOutputSegments {
		return parseAndOutputSegments(input)
	}

	return runImporter(input)
}
