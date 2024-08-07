// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
	legacyDiscovery "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

type RunInput struct {
	ConfigFilePath           string
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

	findInput := legacyDiscovery.FindServiceInput{
		SwaggerDirectory: input.SwaggerDirectory,
		ConfigFilePath:   input.ConfigFilePath,
		OutputDirectory:  input.OutputDirectory,
		Logger:           input.Logger.Named("Discovery"),
	}

	var generationData *[]legacyDiscovery.ServiceInput

	if len(input.Services) > 0 {
		logger.Info(fmt.Sprintf("Finding only the Services %q", strings.Join(input.Services, ", ")))
		generationData, err = legacyDiscovery.FindServicesByName(findInput, *resources, input.Services)
	} else {
		logger.Info("Finding all services.. this may take a while..")
		generationData, err = legacyDiscovery.FindServices(findInput, *resources)
	}

	if err != nil {
		return fmt.Errorf("loading data: %+v", err)
	}

	swaggerGitSha, err := determineGitSha(input.SwaggerDirectory)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", input.SwaggerDirectory, err)
	}

	if input.JustParseData {
		return validateCanParseData(*generationData)
	}

	return runImporter(input, *generationData, *swaggerGitSha)
}
