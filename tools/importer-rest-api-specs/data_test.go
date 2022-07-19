package main

import (
	"fmt"
	"os"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func TestExistingDataCanBeGenerated(t *testing.T) {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	resources, err := definitions.LoadFromDirectory(terraformDefinitionsPath)
	if err != nil {
		t.Fatalf("loading terraform definitions from %q: %+v", terraformDefinitionsPath, err)
	}

	input, err := GenerationData(resourceManagerConfig, swaggerDirectory, *resources, true)
	if err != nil {
		t.Fatalf("building generation data: %+v", err)
	}

	swaggerGitSha, err := determineGitSha(swaggerDirectory)
	if err != nil {
		t.Fatalf("determining Git SHA at %q: %+v", swaggerDirectory, err)
	}

	for _, data := range *input {
		t.Run(fmt.Sprintf("%s-%s", data.ServiceName, data.ApiVersion), func(t *testing.T) {
			generationData := data
			if err := importService(generationData, *swaggerGitSha, nil, true); err != nil {
				t.Fatalf("error: %+v", err)
			}
		})
	}
}
