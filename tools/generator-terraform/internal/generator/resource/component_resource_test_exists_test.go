// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestExistsFuncForResourceTest_CommonId_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "Get",
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := existsFuncForResourceTest(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestExistsFuncForResourceTest_RegularResourceId_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "Get",
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				Segments: []models.ResourceIDSegment{},
			},
		},
	}
	actual, err := existsFuncForResourceTest(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestExistsFuncForResourceTest_CommonId_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2021-01-01",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := existsFuncForResourceTest(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleTestResource) Exists(ctx context.Context, clients *clients.Client, state *pluginsdk.InstanceState) (*bool, error) {
	id, err := commonids.ParseSubscriptionID(state.ID)
	if err != nil {
		return nil, err
	}

	resp, err := clients.Resources.V20210101.SdkResource.Get(ctx, *id)
	if err != nil {
		return nil, fmt.Errorf("reading %s: %+v", *id, err)
	}

	return utils.Bool(resp.Model != nil), nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestExistsFuncForResourceTest_RegularResourceId_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2021-01-01",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				Segments: []models.ResourceIDSegment{},
			},
		},
	}
	actual, err := existsFuncForResourceTest(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleTestResource) Exists(ctx context.Context, clients *clients.Client, state *pluginsdk.InstanceState) (*bool, error) {
	id, err := sdkresource.ParseCustomSubscriptionID(state.ID)
	if err != nil {
		return nil, err
	}

	resp, err := clients.Resources.V20210101.SdkResource.Get(ctx, *id)
	if err != nil {
		return nil, fmt.Errorf("reading %s: %+v", *id, err)
	}

	return utils.Bool(resp.Model != nil), nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
