package main

import (
	"fmt"
	"testing"
)

func TestExistingDataCanBeGenerated(t *testing.T) {
	input := GenerationData()

	swaggerGitSha, err := determineGitSha(swaggerDirectory)
	if err != nil {
		t.Fatalf("determining Git SHA at %q: %+v", swaggerDirectory, err)
	}

	for _, data := range input {
		t.Run(fmt.Sprintf("%s-%s", data.ServiceName, data.ApiVersion), func(t *testing.T) {
			generationData := data
			if err := run(generationData, *swaggerGitSha, true); err != nil {
				t.Fatalf("error: %+v", err)
			}
		})
	}
}
