// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resources

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func TestIdentifyWithCreateAndReadAndUpdateAndDelete(t *testing.T) {
	apiResource := models.APIResource{
		Operations: map[string]models.SDKOperation{
			"Create": {
				Method: "PUT",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Update": {
				Method: "PATCH",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Get": {
				Method: "GET",
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Delete": {
				Method:         "DELETE",
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
		},
		Models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
					"Properties": {},
				},
			},
		},
		ResourceIDs: map[string]models.ResourceID{
			"VirtualNetwork": {
				ExampleValue: "/virtualNetworks/{virtualNetworkName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
					models.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ID:   "/virtualNetworks/{virtualNetworkName}",
			Name: "virtual_network",
		},
	}
	result, err := FindCandidates(apiResource, resources, "Network", hclog.New(hclog.DefaultOptions))
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
	if virtualNetworkResource.CreateMethod.MethodName != "Create" {
		t.Fatalf("expected the Create MethodName to be `Create` but got %q", virtualNetworkResource.CreateMethod.MethodName)
	}
	if virtualNetworkResource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.UpdateMethod.MethodName != "Update" {
		t.Fatalf("expected the Update MethodName to be `Update` but got %q", virtualNetworkResource.UpdateMethod.MethodName)
	}
	if virtualNetworkResource.ReadMethod.MethodName != "Get" {
		t.Fatalf("expected the Read MethodName to be `Get` but got %q", virtualNetworkResource.ReadMethod.MethodName)
	}
	if virtualNetworkResource.DeleteMethod.MethodName != "Delete" {
		t.Fatalf("expected the Delete MethodName to be `Delete` but got %q", virtualNetworkResource.DeleteMethod.MethodName)
	}
}

func TestIdentifyWithCreateOrUpdateAndReadAndDelete(t *testing.T) {
	// shared CreateOrUpdate method
	apiResource := models.APIResource{
		Operations: map[string]models.SDKOperation{
			"CreateOrUpdate": {
				Method: "PUT",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Get": {
				Method: "GET",
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Delete": {
				Method:         "DELETE",
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
		},
		Models: map[string]models.SDKModel{
			"SomeModel": {},
		},
		ResourceIDs: map[string]models.ResourceID{
			"VirtualNetwork": {
				ExampleValue: "/virtualNetworks/{virtualNetworkName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
					models.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ID:   "/virtualNetworks/{virtualNetworkName}",
			Name: "virtual_network",
		},
	}
	result, err := FindCandidates(apiResource, resources, "Network", hclog.New(hclog.DefaultOptions))
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
	if virtualNetworkResource.CreateMethod.MethodName != "CreateOrUpdate" {
		t.Fatalf("expected the Create MethodName to be `CreateOrUpdate` but got %q", virtualNetworkResource.CreateMethod.MethodName)
	}
	if virtualNetworkResource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.UpdateMethod.MethodName != "CreateOrUpdate" {
		t.Fatalf("expected the Update MethodName to be `CreateOrUpdate` but got %q", virtualNetworkResource.UpdateMethod.MethodName)
	}
	if virtualNetworkResource.ReadMethod.MethodName != "Get" {
		t.Fatalf("expected the Read MethodName to be `Get` but got %q", virtualNetworkResource.ReadMethod.MethodName)
	}
	if virtualNetworkResource.DeleteMethod.MethodName != "Delete" {
		t.Fatalf("expected the Delete MethodName to be `Delete` but got %q", virtualNetworkResource.DeleteMethod.MethodName)
	}
}

func TestIdentifyWithCreateOrUpdateAndUpdateAndReadAndDelete(t *testing.T) {
	// shared CreateOrUpdate method but we should use the specific Update method
	apiResource := models.APIResource{
		Operations: map[string]models.SDKOperation{
			"CreateOrUpdate": {
				Method: "PUT",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Update": {
				Method: "PATCH",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModelPatch"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Get": {
				Method: "GET",
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Delete": {
				Method:         "DELETE",
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
		},
		Models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
					"Properties": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("SomeModelProperties"),
						},
					},
				},
			},
			"SomeModelPatch": {
				Fields: map[string]models.SDKField{
					"Properties": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("SomeModelProperties"),
						},
					},
				},
			},
			"SomeModelProperties": {},
		},
		ResourceIDs: map[string]models.ResourceID{
			"VirtualNetwork": {
				ExampleValue: "/virtualNetworks/{virtualNetworkName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
					models.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ID:   "/virtualNetworks/{virtualNetworkName}",
			Name: "virtual_network",
		},
	}
	result, err := FindCandidates(apiResource, resources, "Network", hclog.New(hclog.DefaultOptions))
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
	if virtualNetworkResource.CreateMethod.MethodName != "CreateOrUpdate" {
		t.Fatalf("expected the Create MethodName to be `CreateOrUpdate` but got %q", virtualNetworkResource.CreateMethod.MethodName)
	}
	if virtualNetworkResource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.UpdateMethod.MethodName != "Update" {
		t.Fatalf("expected the Update MethodName to be `Update` but got %q", virtualNetworkResource.UpdateMethod.MethodName)
	}
	if virtualNetworkResource.ReadMethod.MethodName != "Get" {
		t.Fatalf("expected the Read MethodName to be `Get` but got %q", virtualNetworkResource.ReadMethod.MethodName)
	}
	if virtualNetworkResource.DeleteMethod.MethodName != "Delete" {
		t.Fatalf("expected the Delete MethodName to be `Delete` but got %q", virtualNetworkResource.DeleteMethod.MethodName)
	}
}

func TestIdentifyWithCreateOrUpdateAndUpdateAndReadAndDelete_NoProperties(t *testing.T) {
	// whilst there's both a shared CreateOrUpdate method and a specific Update method, since
	// the Update model doesn't contain a `properties` model we should use CreateOrUpdate here
	apiResource := models.APIResource{
		Operations: map[string]models.SDKOperation{
			"CreateOrUpdate": {
				Method: "PUT",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Update": {
				Method: "PATCH",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModelPatch"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Get": {
				Method: "GET",
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Delete": {
				Method:         "DELETE",
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
		},
		Models: map[string]models.SDKModel{
			"SomeModel":      {},
			"SomeModelPatch": {},
		},
		ResourceIDs: map[string]models.ResourceID{
			"VirtualNetwork": {
				ExampleValue: "/virtualNetworks/{virtualNetworkName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
					models.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ID:   "/virtualNetworks/{virtualNetworkName}",
			Name: "virtual_network",
		},
	}
	result, err := FindCandidates(apiResource, resources, "Network", hclog.New(hclog.DefaultOptions))
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
	if virtualNetworkResource.CreateMethod.MethodName != "CreateOrUpdate" {
		t.Fatalf("expected the Create MethodName to be `CreateOrUpdate` but got %q", virtualNetworkResource.CreateMethod.MethodName)
	}
	if virtualNetworkResource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.UpdateMethod.MethodName != "CreateOrUpdate" {
		t.Fatalf("expected the Update MethodName to be `CreateOrUpdate` but got %q", virtualNetworkResource.UpdateMethod.MethodName)
	}
	if virtualNetworkResource.ReadMethod.MethodName != "Get" {
		t.Fatalf("expected the Read MethodName to be `Get` but got %q", virtualNetworkResource.ReadMethod.MethodName)
	}
	if virtualNetworkResource.DeleteMethod.MethodName != "Delete" {
		t.Fatalf("expected the Delete MethodName to be `Delete` but got %q", virtualNetworkResource.DeleteMethod.MethodName)
	}
}

func TestIdentityWithCreateReadDeleteAndUpdateTags(t *testing.T) {
	apiResource := models.APIResource{
		Operations: map[string]models.SDKOperation{
			"CreateOrUpdate": {
				Method: "PUT",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"UpdateTags": {
				Method: "PATCH",
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("Tags"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Get": {
				Method: "GET",
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
			"Delete": {
				Method:         "DELETE",
				ResourceIDName: pointer.To("VirtualNetwork"),
			},
		},
		Models: map[string]models.SDKModel{
			"SomeModel": {},
			"Tags":      {},
		},
		ResourceIDs: map[string]models.ResourceID{
			"VirtualNetwork": {
				ExampleValue: "/virtualNetworks/{virtualNetworkName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("staticVirtualNetworks", "virtualNetworks"),
					models.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
				},
			},
		},
	}
	resources := map[string]definitions.ResourceDefinition{
		"VirtualNetwork": {
			ID:   "/virtualNetworks/{virtualNetworkName}",
			Name: "virtual_network",
		},
	}
	result, err := FindCandidates(apiResource, resources, "Network", hclog.New(hclog.DefaultOptions))
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
	if virtualNetworkResource.CreateMethod.MethodName != "CreateOrUpdate" {
		t.Fatalf("expected the Create MethodName to be `CreateOrUpdate` but got %q", virtualNetworkResource.CreateMethod.MethodName)
	}
	if virtualNetworkResource.UpdateMethod == nil {
		t.Fatalf("expected the Update Method to exist but was nil")
	}
	if virtualNetworkResource.UpdateMethod.MethodName != "CreateOrUpdate" {
		t.Fatalf("expected the Update MethodName to be `CreateOrUpdate` but got %q", virtualNetworkResource.UpdateMethod.MethodName)
	}
	if virtualNetworkResource.ReadMethod.MethodName != "Get" {
		t.Fatalf("expected the Read MethodName to be `Get` but got %q", virtualNetworkResource.ReadMethod.MethodName)
	}
	if virtualNetworkResource.DeleteMethod.MethodName != "Delete" {
		t.Fatalf("expected the Delete MethodName to be `Delete` but got %q", virtualNetworkResource.DeleteMethod.MethodName)
	}
}
