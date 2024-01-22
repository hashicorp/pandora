// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resources

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

func TestIdentifyWithCreateAndReadAndUpdateAndDelete(t *testing.T) {
	services := services.Resource{
		Operations: resourcemanager.ApiOperationDetails{
			Operations: map[string]resourcemanager.ApiOperation{
				"Create": {
					Method: "PUT",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Update": {
					Method: "PATCH",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Get": {
					Method: "GET",
					ResponseObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Delete": {
					Method:         "DELETE",
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
			},
		},
		Schema: resourcemanager.ApiSchemaDetails{
			Models: map[string]resourcemanager.ModelDetails{
				"SomeModel": {
					Fields: map[string]resourcemanager.FieldDetails{
						"Properties": {},
					},
				},
			},
			ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
				"VirtualNetwork": {
					Id: "/virtualNetworks/{virtualNetworkName}",
					Segments: []resourcemanager.ResourceIdSegment{
						{
							Type:       resourcemanager.StaticSegment,
							Name:       "staticVirtualNetworks",
							FixedValue: stringPointer("virtualNetworks"),
						}, {
							Type: resourcemanager.UserSpecifiedSegment,
							Name: "virtualNetworkName",
						},
					},
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
	result, err := FindCandidates(services, resources, "Network", hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.DataSources) != 1 {
		t.Fatalf("expected there to be 1 data source but got %d", len(result.DataSources))
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
	services := services.Resource{
		Operations: resourcemanager.ApiOperationDetails{
			Operations: map[string]resourcemanager.ApiOperation{
				"CreateOrUpdate": {
					Method: "PUT",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Get": {
					Method: "GET",
					ResponseObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Delete": {
					Method:         "DELETE",
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
			},
		},
		Schema: resourcemanager.ApiSchemaDetails{
			Models: map[string]resourcemanager.ModelDetails{
				"SomeModel": {},
			},
			ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
				"VirtualNetwork": {
					Id: "/virtualNetworks/{virtualNetworkName}",
					Segments: []resourcemanager.ResourceIdSegment{
						{
							Type:       resourcemanager.StaticSegment,
							Name:       "staticVirtualNetworks",
							FixedValue: stringPointer("virtualNetworks"),
						}, {
							Type: resourcemanager.UserSpecifiedSegment,
							Name: "virtualNetworkName",
						},
					},
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
	result, err := FindCandidates(services, resources, "Network", hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.DataSources) != 1 {
		t.Fatalf("expected there to be 1 data source but got %d", len(result.DataSources))
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
	services := services.Resource{
		Operations: resourcemanager.ApiOperationDetails{
			Operations: map[string]resourcemanager.ApiOperation{
				"CreateOrUpdate": {
					Method: "PUT",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Update": {
					Method: "PATCH",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModelPatch"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Get": {
					Method: "GET",
					ResponseObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Delete": {
					Method:         "DELETE",
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
			},
		},
		Schema: resourcemanager.ApiSchemaDetails{
			Models: map[string]resourcemanager.ModelDetails{
				"SomeModel": {
					Fields: map[string]resourcemanager.FieldDetails{
						"Properties": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("SomeModelProperties"),
							},
						},
					},
				},
				"SomeModelPatch": {
					Fields: map[string]resourcemanager.FieldDetails{
						"Properties": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("SomeModelProperties"),
							},
						},
					},
				},
				"SomeModelProperties": {},
			},
			ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
				"VirtualNetwork": {
					Id: "/virtualNetworks/{virtualNetworkName}",
					Segments: []resourcemanager.ResourceIdSegment{
						{
							Type:       resourcemanager.StaticSegment,
							Name:       "staticVirtualNetworks",
							FixedValue: stringPointer("virtualNetworks"),
						}, {
							Type: resourcemanager.UserSpecifiedSegment,
							Name: "virtualNetworkName",
						},
					},
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
	result, err := FindCandidates(services, resources, "Network", hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.DataSources) != 1 {
		t.Fatalf("expected there to be 1 data source but got %d", len(result.DataSources))
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
	services := services.Resource{
		Operations: resourcemanager.ApiOperationDetails{
			Operations: map[string]resourcemanager.ApiOperation{
				"CreateOrUpdate": {
					Method: "PUT",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Update": {
					Method: "PATCH",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModelPatch"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Get": {
					Method: "GET",
					ResponseObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Delete": {
					Method:         "DELETE",
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
			},
		},
		Schema: resourcemanager.ApiSchemaDetails{
			Models: map[string]resourcemanager.ModelDetails{
				"SomeModel":      {},
				"SomeModelPatch": {},
			},
			ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
				"VirtualNetwork": {
					Id: "/virtualNetworks/{virtualNetworkName}",
					Segments: []resourcemanager.ResourceIdSegment{
						{
							Type:       resourcemanager.StaticSegment,
							Name:       "staticVirtualNetworks",
							FixedValue: stringPointer("virtualNetworks"),
						}, {
							Type: resourcemanager.UserSpecifiedSegment,
							Name: "virtualNetworkName",
						},
					},
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
	result, err := FindCandidates(services, resources, "Network", hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.DataSources) != 1 {
		t.Fatalf("expected there to be 1 data source but got %d", len(result.DataSources))
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
	services := services.Resource{
		Operations: resourcemanager.ApiOperationDetails{
			Operations: map[string]resourcemanager.ApiOperation{
				"CreateOrUpdate": {
					Method: "PUT",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"UpdateTags": {
					Method: "PATCH",
					RequestObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("Tags"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Get": {
					Method: "GET",
					ResponseObject: &resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeModel"),
					},
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
				"Delete": {
					Method:         "DELETE",
					ResourceIdName: stringPointer("VirtualNetwork"),
				},
			},
		},
		Schema: resourcemanager.ApiSchemaDetails{
			Models: map[string]resourcemanager.ModelDetails{
				"SomeModel": {},
				"Tags":      {},
			},
			ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
				"VirtualNetwork": {
					Id: "/virtualNetworks/{virtualNetworkName}",
					Segments: []resourcemanager.ResourceIdSegment{
						{
							Type:       resourcemanager.StaticSegment,
							Name:       "staticVirtualNetworks",
							FixedValue: stringPointer("virtualNetworks"),
						}, {
							Type: resourcemanager.UserSpecifiedSegment,
							Name: "virtualNetworkName",
						},
					},
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
	result, err := FindCandidates(services, resources, "Network", hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if result == nil {
		t.Fatalf("expected a result but didn't get one")
	}
	if len(result.DataSources) != 1 {
		t.Fatalf("expected there to be 1 data source but got %d", len(result.DataSources))
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

func stringPointer(input string) *string {
	return &input
}
