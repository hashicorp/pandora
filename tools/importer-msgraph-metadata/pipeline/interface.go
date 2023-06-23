package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
)

type RunInput struct {
	Logger hclog.Logger

	ApiVersions        []string
	MetadataDirectory  string
	OpenApiFilePattern string
	OutputDirectory    string
	ProviderPrefix     string
	Tags               []string

	// ModelsPerService will output models and constants for each service, duplicating where necessary. However, this
	// yields >400,000 files at over 1.5GB, so setting this to false will instead output a single Models namespace
	ModelsPerService bool
}

func Run(input RunInput) error {
	logger := input.Logger

	metadataGitSha, err := determineGitSha(input.MetadataDirectory, logger)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", input.MetadataDirectory, err)
	}

	return runImporter(input, *metadataGitSha)
}
