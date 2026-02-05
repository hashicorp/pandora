// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package identification

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func TestIdentityWithinServiceCreateAndReadAndUpdateAndDelete(t *testing.T) {
	t.Parallel()
	service := sdkModels.Service{
		Name:     "Networking",
		Generate: true,
		APIVersions: map[string]sdkModels.APIVersion{
			"2020-01-01": {
				APIVersion: "2020-01-01",
				Generate:   true,
				Resources: map[string]sdkModels.APIResource{
					"VirtualNetworks": {
						Operations: map[string]sdkModels.SDKOperation{
							"Create": {
								Method: "PUT",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Update": {
								Method: "PATCH",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Get": {
								Method: "GET",
								ResponseObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Delete": {
								Method:         "DELETE",
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
						},
						Models: map[string]sdkModels.SDKModel{
							"SomeModel": {
								Fields: map[string]sdkModels.SDKField{
									"Properties": {},
								},
							},
						},
						ResourceIDs: map[string]sdkModels.ResourceID{
							"VirtualNetwork": {
								ExampleValue: "/virtualNetworks/{virtualNetworkName}",
								Segments: []sdkModels.ResourceIDSegment{
									sdkModels.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
									sdkModels.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
								},
							},
						},
					},
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ServiceName:    "Networking",
			APIVersion:     "2020-01-01",
			APIResource:    "VirtualNetworks",
			ResourceLabel:  "virtual_network",
			ID:             "/virtualNetworks/{virtualNetworkName}",
			Name:           "virtual_network",
			GenerateCreate: true,
			GenerateDelete: true,
			GenerateRead:   true,
			GenerateUpdate: true,
			TestData:       definitions.ResourceTestDataDefinition{},
			Overrides:      &[]definitions.Override{},
		},
	}
	result, err := WithinService("azurerm", service, resources)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected there to be 1 resources but got %d", len(result.Resources))
	}
	virtualNetworkResource, ok := result.Resources["VirtualNetwork"]
	if !ok {
		t.Fatalf("expected there to be a resource named `VirtualNetwork` but there wasn't")
	}
	if virtualNetworkResource.Resource.CreateMethod.SDKOperationName != "Create" {
		t.Fatalf("expected the Create SDKOperationName to be `Create` but got %q", virtualNetworkResource.Resource.CreateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.Resource.UpdateMethod.SDKOperationName != "Update" {
		t.Fatalf("expected the Update SDKOperationName to be `Update` but got %q", virtualNetworkResource.Resource.UpdateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.ReadMethod.SDKOperationName != "Get" {
		t.Fatalf("expected the Read SDKOperationName to be `Get` but got %q", virtualNetworkResource.Resource.ReadMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.DeleteMethod.SDKOperationName != "Delete" {
		t.Fatalf("expected the Delete SDKOperationName to be `Delete` but got %q", virtualNetworkResource.Resource.DeleteMethod.SDKOperationName)
	}
}

func TestIdentityWithinServiceCreateOrUpdateAndReadAndDelete(t *testing.T) {
	t.Parallel(
	// shared CreateOrUpdate method
	)

	service := sdkModels.Service{
		Name:     "Networking",
		Generate: true,
		APIVersions: map[string]sdkModels.APIVersion{
			"2020-01-01": {
				APIVersion: "2020-01-01",
				Generate:   true,
				Resources: map[string]sdkModels.APIResource{
					"VirtualNetworks": {
						Operations: map[string]sdkModels.SDKOperation{
							"CreateOrUpdate": {
								Method: "PUT",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Get": {
								Method: "GET",
								ResponseObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Delete": {
								Method:         "DELETE",
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
						},
						Models: map[string]sdkModels.SDKModel{
							"SomeModel": {},
						},
						ResourceIDs: map[string]sdkModels.ResourceID{
							"VirtualNetwork": {
								ExampleValue: "/virtualNetworks/{virtualNetworkName}",
								Segments: []sdkModels.ResourceIDSegment{
									sdkModels.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
									sdkModels.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
								},
							},
						},
					},
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ServiceName:    "Networking",
			APIVersion:     "2020-01-01",
			APIResource:    "VirtualNetworks",
			ResourceLabel:  "virtual_network",
			ID:             "/virtualNetworks/{virtualNetworkName}",
			Name:           "virtual_network",
			GenerateCreate: true,
			GenerateDelete: true,
			GenerateRead:   true,
			GenerateUpdate: true,
			TestData:       definitions.ResourceTestDataDefinition{},
			Overrides:      &[]definitions.Override{},
		},
	}
	result, err := WithinService("azurerm", service, resources)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected there to be 1 resources but got %d", len(result.Resources))
	}
	virtualNetworkResource, ok := result.Resources["VirtualNetwork"]
	if !ok {
		t.Fatalf("expected there to be a resource named `VirtualNetwork` but there wasn't")
	}
	if virtualNetworkResource.Resource.CreateMethod.SDKOperationName != "CreateOrUpdate" {
		t.Fatalf("expected the Create SDKOperationName to be `CreateOrUpdate` but got %q", virtualNetworkResource.Resource.CreateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.Resource.UpdateMethod.SDKOperationName != "CreateOrUpdate" {
		t.Fatalf("expected the Update SDKOperationName to be `CreateOrUpdate` but got %q", virtualNetworkResource.Resource.UpdateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.ReadMethod.SDKOperationName != "Get" {
		t.Fatalf("expected the Read SDKOperationName to be `Get` but got %q", virtualNetworkResource.Resource.ReadMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.DeleteMethod.SDKOperationName != "Delete" {
		t.Fatalf("expected the Delete SDKOperationName to be `Delete` but got %q", virtualNetworkResource.Resource.DeleteMethod.SDKOperationName)
	}
}

func TestIdentityWithinServiceCreateOrUpdateAndUpdateAndReadAndDelete(t *testing.T) {
	t.Parallel(
	// shared CreateOrUpdate method but we should use the specific Update method
	)

	service := sdkModels.Service{
		Name:     "Networking",
		Generate: true,
		APIVersions: map[string]sdkModels.APIVersion{
			"2020-01-01": {
				APIVersion: "2020-01-01",
				Generate:   true,
				Resources: map[string]sdkModels.APIResource{
					"VirtualNetworks": {
						Operations: map[string]sdkModels.SDKOperation{
							"CreateOrUpdate": {
								Method: "PUT",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Update": {
								Method: "PATCH",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModelPatch"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Get": {
								Method: "GET",
								ResponseObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Delete": {
								Method:         "DELETE",
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
						},
						Models: map[string]sdkModels.SDKModel{
							"SomeModel": {
								Fields: map[string]sdkModels.SDKField{
									"Properties": {
										ObjectDefinition: sdkModels.SDKObjectDefinition{
											Type:          sdkModels.ReferenceSDKObjectDefinitionType,
											ReferenceName: pointer.To("SomeModelProperties"),
										},
									},
								},
							},
							"SomeModelPatch": {
								Fields: map[string]sdkModels.SDKField{
									"Properties": {
										ObjectDefinition: sdkModels.SDKObjectDefinition{
											Type:          sdkModels.ReferenceSDKObjectDefinitionType,
											ReferenceName: pointer.To("SomeModelProperties"),
										},
									},
								},
							},
							"SomeModelProperties": {},
						},
						ResourceIDs: map[string]sdkModels.ResourceID{
							"VirtualNetwork": {
								ExampleValue: "/virtualNetworks/{virtualNetworkName}",
								Segments: []sdkModels.ResourceIDSegment{
									sdkModels.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
									sdkModels.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
								},
							},
						},
					},
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ServiceName:    "Networking",
			APIVersion:     "2020-01-01",
			APIResource:    "VirtualNetworks",
			ResourceLabel:  "virtual_network",
			ID:             "/virtualNetworks/{virtualNetworkName}",
			Name:           "virtual_network",
			GenerateCreate: true,
			GenerateDelete: true,
			GenerateRead:   true,
			GenerateUpdate: true,
			TestData:       definitions.ResourceTestDataDefinition{},
			Overrides:      &[]definitions.Override{},
		},
	}
	result, err := WithinService("azurerm", service, resources)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected there to be 1 resources but got %d", len(result.Resources))
	}
	virtualNetworkResource, ok := result.Resources["VirtualNetwork"]
	if !ok {
		t.Fatalf("expected there to be a resource named `VirtualNetwork` but there wasn't")
	}
	if virtualNetworkResource.Resource.CreateMethod.SDKOperationName != "CreateOrUpdate" {
		t.Fatalf("expected the Create SDKOperationName to be `CreateOrUpdate` but got %q", virtualNetworkResource.Resource.CreateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.Resource.UpdateMethod.SDKOperationName != "Update" {
		t.Fatalf("expected the Update SDKOperationName to be `Update` but got %q", virtualNetworkResource.Resource.UpdateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.ReadMethod.SDKOperationName != "Get" {
		t.Fatalf("expected the Read SDKOperationName to be `Get` but got %q", virtualNetworkResource.Resource.ReadMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.DeleteMethod.SDKOperationName != "Delete" {
		t.Fatalf("expected the Delete SDKOperationName to be `Delete` but got %q", virtualNetworkResource.Resource.DeleteMethod.SDKOperationName)
	}
}

func TestIdentityWithinServiceCreateOrUpdateAndUpdateAndReadAndDelete_NoProperties(t *testing.T) {
	t.Parallel(
	// whilst there's both a shared CreateOrUpdate method and a specific Update method, since
	// the Update model doesn't contain a `properties` model we should use CreateOrUpdate here
	)

	service := sdkModels.Service{
		Name:     "Networking",
		Generate: true,
		APIVersions: map[string]sdkModels.APIVersion{
			"2020-01-01": {
				APIVersion: "2020-01-01",
				Generate:   true,
				Resources: map[string]sdkModels.APIResource{
					"VirtualNetworks": {
						Operations: map[string]sdkModels.SDKOperation{
							"CreateOrUpdate": {
								Method: "PUT",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Update": {
								Method: "PATCH",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModelPatch"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Get": {
								Method: "GET",
								ResponseObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Delete": {
								Method:         "DELETE",
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
						},
						Models: map[string]sdkModels.SDKModel{
							"SomeModel":      {},
							"SomeModelPatch": {},
						},
						ResourceIDs: map[string]sdkModels.ResourceID{
							"VirtualNetwork": {
								ExampleValue: "/virtualNetworks/{virtualNetworkName}",
								Segments: []sdkModels.ResourceIDSegment{
									sdkModels.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
									sdkModels.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
								},
							},
						},
					},
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ServiceName:    "Networking",
			APIVersion:     "2020-01-01",
			APIResource:    "VirtualNetworks",
			ResourceLabel:  "virtual_network",
			ID:             "/virtualNetworks/{virtualNetworkName}",
			Name:           "virtual_network",
			GenerateCreate: true,
			GenerateDelete: true,
			GenerateRead:   true,
			GenerateUpdate: true,
			TestData:       definitions.ResourceTestDataDefinition{},
			Overrides:      &[]definitions.Override{},
		},
	}
	result, err := WithinService("azurerm", service, resources)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected there to be 1 resources but got %d", len(result.Resources))
	}
	virtualNetworkResource, ok := result.Resources["VirtualNetwork"]
	if !ok {
		t.Fatalf("expected there to be a resource named `VirtualNetwork` but there wasn't")
	}
	if virtualNetworkResource.Resource.CreateMethod.SDKOperationName != "CreateOrUpdate" {
		t.Fatalf("expected the Create SDKOperationName to be `CreateOrUpdate` but got %q", virtualNetworkResource.Resource.CreateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.Resource.UpdateMethod.SDKOperationName != "CreateOrUpdate" {
		t.Fatalf("expected the Update SDKOperationName to be `CreateOrUpdate` but got %q", virtualNetworkResource.Resource.UpdateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.ReadMethod.SDKOperationName != "Get" {
		t.Fatalf("expected the Read SDKOperationName to be `Get` but got %q", virtualNetworkResource.Resource.ReadMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.DeleteMethod.SDKOperationName != "Delete" {
		t.Fatalf("expected the Delete SDKOperationName to be `Delete` but got %q", virtualNetworkResource.Resource.DeleteMethod.SDKOperationName)
	}
}

func TestIdentityWithinServiceCreateReadDeleteAndUpdateTags(t *testing.T) {
	t.Parallel()
	service := sdkModels.Service{
		Name:     "Networking",
		Generate: true,
		APIVersions: map[string]sdkModels.APIVersion{
			"2020-01-01": {
				APIVersion: "2020-01-01",
				Generate:   true,
				Resources: map[string]sdkModels.APIResource{
					"VirtualNetworks": {
						Operations: map[string]sdkModels.SDKOperation{
							"CreateOrUpdate": {
								Method: "PUT",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"UpdateTags": {
								Method: "PATCH",
								RequestObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("Tags"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Get": {
								Method: "GET",
								ResponseObject: &sdkModels.SDKObjectDefinition{
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									ReferenceName: pointer.To("SomeModel"),
								},
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
							"Delete": {
								Method:         "DELETE",
								ResourceIDName: pointer.To("VirtualNetwork"),
							},
						},
						Models: map[string]sdkModels.SDKModel{
							"SomeModel": {},
							"Tags":      {},
						},
						ResourceIDs: map[string]sdkModels.ResourceID{
							"VirtualNetwork": {
								ExampleValue: "/virtualNetworks/{virtualNetworkName}",
								Segments: []sdkModels.ResourceIDSegment{
									sdkModels.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
									sdkModels.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
								},
							},
						},
					},
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ServiceName:    "Networking",
			APIVersion:     "2020-01-01",
			APIResource:    "VirtualNetworks",
			ResourceLabel:  "virtual_network",
			ID:             "/virtualNetworks/{virtualNetworkName}",
			Name:           "virtual_network",
			GenerateCreate: true,
			GenerateDelete: true,
			GenerateRead:   true,
			GenerateUpdate: true,
			TestData:       definitions.ResourceTestDataDefinition{},
			Overrides:      &[]definitions.Override{},
		},
	}
	result, err := WithinService("azurerm", service, resources)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected there to be 1 resources but got %d", len(result.Resources))
	}
	virtualNetworkResource, ok := result.Resources["VirtualNetwork"]
	if !ok {
		t.Fatalf("expected there to be a resource named `VirtualNetwork` but there wasn't")
	}
	if virtualNetworkResource.Resource.CreateMethod.SDKOperationName != "CreateOrUpdate" {
		t.Fatalf("expected the Create SDKOperationName to be `CreateOrUpdate` but got %q", virtualNetworkResource.Resource.CreateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.Resource.UpdateMethod.SDKOperationName != "CreateOrUpdate" {
		t.Fatalf("expected the Update SDKOperationName to be `CreateOrUpdate` but got %q", virtualNetworkResource.Resource.UpdateMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.ReadMethod.SDKOperationName != "Get" {
		t.Fatalf("expected the Read SDKOperationName to be `Get` but got %q", virtualNetworkResource.Resource.ReadMethod.SDKOperationName)
	}
	if virtualNetworkResource.Resource.DeleteMethod.SDKOperationName != "Delete" {
		t.Fatalf("expected the Delete SDKOperationName to be `Delete` but got %q", virtualNetworkResource.Resource.DeleteMethod.SDKOperationName)
	}
}
