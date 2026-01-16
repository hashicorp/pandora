// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package discovery

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func TestDetermineResourceProviderForService(t *testing.T) {
	testData := []struct {
		serviceDirectory string
		serviceName      string
		filePaths        []string
		expected         *string
	}{
		{
			// Basic
			serviceDirectory: "/path/specification/addons",
			serviceName:      "addons",
			filePaths: []string{
				"/path/specification/addons/resource-manager/Microsoft.Addons/preview/2017-05-15/Addons.json",
				"/path/specification/addons/resource-manager/Microsoft.Addons/preview/2017-05-15/examples/CanonicalSupportPlanTypes_Get.json",
				"/path/specification/addons/resource-manager/Microsoft.Addons/preview/2017-05-15/examples/Operations_List.json",
				"/path/specification/addons/resource-manager/Microsoft.Addons/preview/2017-05-15/examples/SupportPlanTypes_CreateOrUpdate.json",
				"/path/specification/addons/resource-manager/Microsoft.Addons/preview/2017-05-15/examples/SupportPlanTypes_Delete.json",
				"/path/specification/addons/resource-manager/Microsoft.Addons/preview/2017-05-15/examples/SupportPlanTypes_Get.json",
			},
			expected: pointer.To("Microsoft.Addons"),
		},
		{
			// Legacy - Service Group
			serviceDirectory: "/path/specification/mediaservices",
			serviceName:      "mediaservices",
			filePaths: []string{
				"/path/specification/mediaservices/resource-manager/Microsoft.Media/Accounts/stable/2023-01-01/Accounts.json",
				"/path/specification/mediaservices/resource-manager/Microsoft.Media/Encoding/stable/2023-01-01/Encoding.json",
				"/path/specification/mediaservices/resource-manager/Microsoft.Media/Metadata/stable/2023-01-01/Metadata.json",
				"/path/specification/mediaservices/resource-manager/Microsoft.Media/Streaming/stable/2023-01-01/Streaming.json",
			},
			expected: pointer.To("Microsoft.Media"),
		},
		{
			// Multiple Resource Providers with one that looks like a default
			// In this scenario since there's an RP matching the Service Name, we can infer that's the default Resource Provider
			// for this Service. If this is wrong, this can be overridden in the Configuration file.
			serviceDirectory: "/path/specification/compute",
			serviceName:      "compute",
			filePaths: []string{
				"/path/specification/compute/resource-manager/Microsoft.Compute/CloudserviceRP/stable/2022-09-04/SomeFile.json",
				"/path/specification/compute/resource-manager/Microsoft.ContainerService/stable/2020-01-01/SomeFile.json",
			},
			expected: pointer.To("Microsoft.Compute"), // inferrable from the Service Name
		},
		{
			// Multiple Resource Providers with totally different names
			// In this scenario this method shouldn't be called, the RP in question should be provided in the config
			serviceDirectory: "/path/specification/containers",
			serviceName:      "containers",
			filePaths: []string{
				"/path/specification/compute/resource-manager/Microsoft.ContainerApps/stable/2020-01-01/SomeFile.json",
				"/path/specification/compute/resource-manager/Microsoft.ContainerService/stable/2022-09-04/SomeFile.json",
			},
			expected: nil, // should be an error
		},
	}
	logging.Log = hclog.New(hclog.DefaultOptions)

	for i, input := range testData {
		t.Logf("Iteration %d..", i)
		actual, err := determineDefaultResourceProviderForService(input.serviceDirectory, input.serviceName, input.filePaths)
		if err != nil {
			if input.expected == nil {
				continue
			}

			t.Fatal(err.Error())
		}
		if input.expected == nil {
			if actual == nil {
				continue
			}

			t.Fatalf("expected an error but got %q", *actual)
		}
		if *actual != *input.expected {
			t.Fatalf("expected %q but got %q", *input.expected, *actual)
		}
	}
}
