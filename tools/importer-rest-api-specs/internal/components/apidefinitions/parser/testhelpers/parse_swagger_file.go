package testhelpers

import (
	"path/filepath"
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions"
	discoveryModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
)

func ParseSwaggerFileForTesting(t *testing.T, filePath string) (*sdkModels.APIVersion, error) {
	input := discoveryModels.AvailableDataSet{
		ServiceName: "Example",
		DataSetsForAPIVersions: map[string]discoveryModels.AvailableDataSetForAPIVersion{
			"2020-01-01": {
				APIVersion:               "2020-01-01",
				ContainsStableAPIVersion: false,
				FilePathsContainingAPIDefinitions: []string{
					filepath.Join("testdata", filePath),
				},
				FilePathsContainingSupplementaryData: []string{},
			},
		},
		ResourceProvider: nil,
	}
	result, err := apidefinitions.ParseService(input)
	if err != nil {
		t.Fatalf(err.Error())
	}
	apiVersion, ok := result.APIVersions["2020-01-01"]
	if !ok {
		t.Fatalf("expected an API Version `2020-01-01` but didn't get one")
	}
	return &apiVersion, nil
}
