// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestWorkaroundWeb40128(t *testing.T) {
	versions := []string{"2023-01-01", "2023-12-01", "2024-11-01", "2025-05-01"}

	for _, version := range versions {
		t.Run(version, func(t *testing.T) {
			input := sdkModels.APIVersion{
				APIVersion: version,
				Resources: map[string]sdkModels.APIResource{
					"WebApps": {
						Models: map[string]sdkModels.SDKModel{
							"AzureStorageInfoValue": {
								Fields: map[string]sdkModels.SDKField{},
							},
						},
					},
				},
			}

			workaround := workaroundWeb40128{}
			if !workaround.IsApplicable("Web", input) {
				t.Fatalf("expected workaround to apply to Web %q", version)
			}

			result, err := workaround.Process(input)
			if err != nil {
				t.Fatalf("processing workaround: %+v", err)
			}

			field := result.Resources["WebApps"].Models["AzureStorageInfoValue"].Fields["Endpoint"]
			if field.JsonName != "endpoint" {
				t.Errorf("expected JsonName to be %q, got %q", "endpoint", field.JsonName)
			}
			if !field.Optional {
				t.Error("expected Endpoint to be optional")
			}
			if field.ObjectDefinition.Type != sdkModels.StringSDKObjectDefinitionType {
				t.Errorf("expected Endpoint to be a string, got %q", field.ObjectDefinition.Type)
			}
		})
	}
}

func TestWorkaroundWeb40128IsNotApplicable(t *testing.T) {
	workaround := workaroundWeb40128{}

	for _, test := range []struct {
		service string
		version string
	}{
		{service: "Compute", version: "2023-12-01"},
		{service: "Web", version: "2016-06-01"},
	} {
		if workaround.IsApplicable(test.service, sdkModels.APIVersion{APIVersion: test.version}) {
			t.Errorf("expected workaround not to apply to %s %s", test.service, test.version)
		}
	}
}
