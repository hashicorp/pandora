package discovery

import "testing"

func TestGetMetaDataForSwaggerDirectory(t *testing.T) {
	testData := []struct {
		input    []string
		expected *swaggerDirectoryMetaData
	}{
		{
			input: []string{
				"not",
				"enough",
				"segments",
			},
			expected: nil,
		},
		{
			// Data Plane URIs aren't valid
			input: []string{
				"appconfiguration",
				"data-plane",
				"Microsoft.AppConfiguration",
				"stable",
				"1.0",
			},
			expected: nil,
		},
		{
			// Resource Manager (most items) - Stable
			input: []string{
				"vmware",
				"resource-manager",
				"Microsoft.AVS",
				"stable",
				"2022-01-01",
			},
			expected: &swaggerDirectoryMetaData{
				serviceName:         "vmware",
				serviceType:         "resource-manager",
				resourceProvider:    "Microsoft.AVS",
				serviceReleaseState: "stable",
				apiVersion:          "2022-01-01",
			},
		},
		{
			// Resource Manager (most items) - Preview
			input: []string{
				"vmware",
				"resource-manager",
				"Microsoft.AVS",
				"preview",
				"2022-01-01",
			},
			expected: &swaggerDirectoryMetaData{
				serviceName:         "vmware",
				serviceType:         "resource-manager",
				resourceProvider:    "Microsoft.AVS",
				serviceReleaseState: "preview",
				apiVersion:          "2022-01-01",
			},
		},
		{
			// Resource Manager (most items) - Unknown
			input: []string{
				"vmware",
				"resource-manager",
				"Microsoft.AVS",
				"mercury",
				"2022-01-01",
			},
			expected: nil,
		},
	}
	for i, data := range testData {
		t.Logf("Iteration %d..", i)

		actual := getMetaDataForSwaggerDirectory(data.input)
		if actual == nil {
			if data.expected == nil {
				continue
			}
			t.Fatalf("expected a result but didn't get one")
		}
		if data.expected == nil {
			t.Fatalf("expected no result but got: %s", actual.String())
		}

		if actual.serviceName != data.expected.serviceName {
			t.Fatalf("expected serviceName to be %q but got %q", data.expected.serviceName, actual.serviceName)
		}
		if actual.serviceType != data.expected.serviceType {
			t.Fatalf("expected serviceType to be %q but got %q", data.expected.serviceType, actual.serviceType)
		}
		if actual.resourceProvider != data.expected.resourceProvider {
			t.Fatalf("expected resourceProvider to be %q but got %q", data.expected.resourceProvider, actual.resourceProvider)
		}
		if actual.serviceReleaseState != data.expected.serviceReleaseState {
			t.Fatalf("expected serviceReleaseState to be %q but got %q", data.expected.serviceReleaseState, actual.serviceReleaseState)
		}
		if actual.apiVersion != data.expected.apiVersion {
			t.Fatalf("expected apiVersion to be %q but got %q", data.expected.apiVersion, actual.apiVersion)
		}
	}
}
