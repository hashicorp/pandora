// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testhelpers

import (
	"path/filepath"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions"
	discoveryModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
)

func ParseSwaggerFileForTesting(t *testing.T, filePath string, serviceName *string) (*sdkModels.APIVersion, error) {
	if serviceName == nil {
		serviceName = pointer.To("Example")
	}
	input := discoveryModels.AvailableDataSet{
		ServiceName: *serviceName,
		DataSetsForAPIVersions: map[string]discoveryModels.AvailableDataSetForAPIVersion{
			"2020-01-01": {
				APIVersion:               "2020-01-01",
				ContainsStableAPIVersion: false,
				FilePathsContainingAPIDefinitions: []string{
					filepath.Join("testdata", filePath),
				},
			},
		},
		ResourceProvider: nil,
	}
	return ParseDataSetForTesting(t, input, "2020-01-01")
}

func ParseDataSetForTesting(t *testing.T, input discoveryModels.AvailableDataSet, apiVersion string) (*sdkModels.APIVersion, error) {
	result, err := apidefinitions.ParseService(input, 0)
	if err != nil {
		t.Fatal(err.Error())
	}
	out, ok := result.APIVersions[apiVersion]
	if !ok {
		t.Fatalf("expected an API Version `%s` but didn't get one", apiVersion)
	}
	return &out, nil
}
