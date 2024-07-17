package parser_test

import (
	"path/filepath"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/testhelpers"
	discoveryModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
)

func TestParseSupplementaryData(t *testing.T) {
	dataSet := discoveryModels.AvailableDataSet{
		ServiceName: "Example",
		DataSetsForAPIVersions: map[string]discoveryModels.AvailableDataSetForAPIVersion{
			"2020-01-01": {
				APIVersion:               "2020-01-01",
				ContainsStableAPIVersion: true,
				FilePathsContainingAPIDefinitions: []string{
					filepath.Join("testdata", "supplementary_data_parent.json"),
				},
				FilePathsContainingSupplementaryData: []string{
					filepath.Join("testdata", "supplementary_data_implementations.json"),
				},
			},
		},
		ResourceProvider: nil,
	}
	actual, err := testhelpers.ParseDataSetForTesting(t, dataSet, "2020-01-01")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Constants: make(map[string]sdkModels.SDKConstant),
				Models: map[string]sdkModels.SDKModel{
					"Cat":        {},
					"ParentType": {},
				},
				Name: "Example",
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("ParentType"),
						},
					},
				},
				ResourceIDs: map[string]sdkModels.ResourceID{},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}
