package testhelpers

import (
	"fmt"
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func ParseSwaggerFileForTesting(t *testing.T, filePath string) (*sdkModels.APIVersion, error) {
	/*
		parsed, err := load("testdata/", file)
			if err != nil {
				t.Fatalf("loading: %+v", err)
			}

			var resourceProvider *string = nil // we're not filtering to just this RP, so it's fine
			resourceIds, err := parsed.ParseResourceIds()
			if err != nil {
				t.Fatalf("parsing Resource Ids: %+v", err)
			}

			service := "Example"
			if serviceName != nil {
				service = *serviceName
			}
			out, err := parsed.parse(service, "2020-01-01", resourceProvider, *resourceIds)
			if err != nil {
				t.Fatalf("parsing file %q: %+v", file, err)
			}

			// removeUnusedItems used to be called as we iterated through the swagger files
			// it's now called once after all the processing for a service has been done so must be called here
			// to replicate the entire parsing process for swagger files
			out.Resources = removeUnusedItems(out.Resources)

			return out, nil
	*/

	return nil, fmt.Errorf("TODO")
}
