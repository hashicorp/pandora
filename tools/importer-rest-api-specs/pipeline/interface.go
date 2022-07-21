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
