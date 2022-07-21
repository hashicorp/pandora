package main

import (
	"fmt"
	"os"
	"testing"

	"github.com/hashicorp/go-hclog"

	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func TestExistingDataCanBeGenerated(t *testing.T) {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	resources, err := definitions.LoadFromDirectory(terraformDefinitionsPath)
	if err != nil {
		t.Fatalf("loading terraform definitions from %q: %+v", terraformDefinitionsPath, err)
	}

	input, err := GenerationData(resourceManagerConfig, swaggerDirectory, *resources, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("building generation data: %+v", err)
	}

	swaggerGitSha, err := determineGitSha(swaggerDirectory, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("determining Git SHA at %q: %+v", swaggerDirectory, err)
	}

	for _, data := range *input {
		t.Run(fmt.Sprintf("%s-%s", data.ServiceName, data.ApiVersion), func(t *testing.T) {
			generationData := data
			if err := importService(generationData, *swaggerGitSha, nil, hclog.New(hclog.DefaultOptions)); err != nil {
				t.Fatalf("error: %+v", err)
			}
		})
	}
}
