package main

import (
	"fmt"
	"os"
	"testing"
)

func TestExistingDataCanBeGenerated(t *testing.T) {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	input, err := GenerationData(resourceManagerConfig, swaggerDirectory, true)
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
			if err := importService(generationData, *swaggerGitSha, true); err != nil {
				t.Fatalf("error: %+v", err)
			}
		})
	}
}
