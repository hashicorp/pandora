// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package parser_test

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/testhelpers"
)

func TestParseResourceIdBasic(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_basic.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ServerId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							sdkModels.NewStaticValueResourceIDSegment("staticServers", "servers"),
							sdkModels.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ServerId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAConstant(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_containing_constant.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Constants: map[string]sdkModels.SDKConstant{
					"Planet": {
						Type: sdkModels.StringSDKConstantType,
						Values: map[string]string{
							"Earth":   "Earth",
							"Jupiter": "Jupiter",
							"Mars":    "Mars",
							"Saturn":  "Saturn",
						},
					},
				},
				ResourceIDs: map[string]sdkModels.ResourceID{
					"PlanetId": {
						ConstantNames: []string{
							"Planet",
						},
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticPlanets", "planets"),
							sdkModels.NewConstantResourceIDSegment("planetName", "Planet", "Earth"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"OperationContainingAConstant": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("PlanetId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAScope(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_containing_scope.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ScopedVirtualMachineId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewScopeResourceIDSegment("scope"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							sdkModels.NewStaticValueResourceIDSegment("staticVirtualMachines", "virtualMachines"),
							sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachinesName"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"OperationContainingAScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ScopedVirtualMachineId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAHiddenScope(t *testing.T) {
	t.Parallel()
	files := []string{
		"resource_ids_containing_hidden_scope.json",
		"resource_ids_containing_hidden_scope_constant.json",
		"resource_ids_containing_hidden_scope_hardcoded_provider.json",
	}
	for _, file := range files {
		t.Run(file, func(t *testing.T) {
			fileName := file

			actual, err := testhelpers.ParseSwaggerFileForTesting(t, fileName, nil)
			if err != nil {
				t.Fatalf("parsing: %+v", err)
			}

			expected := sdkModels.APIVersion{
				APIVersion: "2020-01-01",
				Resources: map[string]sdkModels.APIResource{
					"Example": {
						ResourceIDs: map[string]sdkModels.ResourceID{
							"ScopeId": {
								CommonIDAlias: pointer.To("Scope"),
								Segments: []sdkModels.ResourceIDSegment{
									sdkModels.NewScopeResourceIDSegment("scope"),
								},
							},
						},
						Operations: map[string]sdkModels.SDKOperation{
							"OperationContainingAHiddenScope": {
								ContentType:         "application/json",
								ExpectedStatusCodes: []int{200},
								Method:              "HEAD",
								ResourceIDName:      pointer.To("ScopeId"),
							},
						},
					},
				},
			}
			testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
		})
	}
}

func TestParseResourceIdContainingAHiddenScopeWithExtraSegment(t *testing.T) {
	t.Parallel(
	// The extra segment should be ignored and detected as a regular scope
	)

	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_containing_hidden_scope_with_extra_segment.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewScopeResourceIDSegment("scope"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"OperationContainingAHiddenScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ScopeId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAHiddenScopeWithSuffix(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_containing_hidden_scope_with_suffix.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewScopeResourceIDSegment("scope"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"OperationContainingAHiddenScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ScopeId"),
						URISuffix:           pointer.To("/someEndpoint"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAHiddenScopeNested(t *testing.T) {
	t.Parallel()
	files := []string{
		"resource_ids_containing_hidden_scope_nested.json",
		"resource_ids_containing_hidden_scope_nested_constants.json",
		"resource_ids_containing_hidden_scope_nested_hardcoded_provider.json",
	}
	for _, file := range files {
		t.Run(file, func(t *testing.T) {
			fileName := file

			actual, err := testhelpers.ParseSwaggerFileForTesting(t, fileName, nil)
			if err != nil {
				t.Fatalf("parsing: %+v", err)
			}

			expected := sdkModels.APIVersion{
				APIVersion: "2020-01-01",
				Resources: map[string]sdkModels.APIResource{
					"Example": {
						ResourceIDs: map[string]sdkModels.ResourceID{
							"ScopeId": {
								CommonIDAlias: pointer.To("Scope"),
								Segments: []sdkModels.ResourceIDSegment{
									sdkModels.NewScopeResourceIDSegment("scope"),
								},
							},
						},
						Operations: map[string]sdkModels.SDKOperation{
							"OperationContainingAHiddenScope": {
								ContentType:         "application/json",
								ExpectedStatusCodes: []int{200},
								Method:              "HEAD",
								ResourceIDName:      pointer.To("ScopeId"),
							},
						},
					},
				},
			}
			testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
		})
	}
}

func TestParseResourceIdContainingAHiddenScopeNestedWithExtraSegment(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_containing_hidden_scope_nested_with_extra_segment.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewScopeResourceIDSegment("scope"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"OperationContainingAHiddenScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ScopeId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAHiddenScopeNestedWithSuffix(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_containing_hidden_scope_nested_with_suffix.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewScopeResourceIDSegment("scope"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"OperationContainingAHiddenScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ScopeId"),
						URISuffix:           pointer.To("/someEndpoint"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdWithJustUriSuffix(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_with_just_suffix.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Operations: map[string]sdkModels.SDKOperation{
					"JustSuffix": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/restart"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdWithResourceIdAndUriSuffix(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_with_suffix.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ServerId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							sdkModels.NewStaticValueResourceIDSegment("staticServers", "servers"),
							sdkModels.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ServerId"),
						URISuffix:           pointer.To("/someOperation"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdWithResourceIdAndUriSuffixForMultipleUris(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_with_suffix_multiple_uris.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ServerId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							sdkModels.NewStaticValueResourceIDSegment("staticServers", "servers"),
							sdkModels.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Restart": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ServerId"),
						URISuffix:           pointer.To("/restart"),
					},
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ServerId"),
						URISuffix:           pointer.To("/someOperation"),
					},
					"TopLevel": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ServerId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingResourceProviderShouldGetTitleCased(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_lowercased_resource_provider.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ServerId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							sdkModels.NewStaticValueResourceIDSegment("staticServers", "servers"),
							sdkModels.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ServerId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingTheSameResourceIdWithDifferentSegments(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_same_id_different_segment_casing.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"VirtualMachineId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							sdkModels.NewStaticValueResourceIDSegment("staticVirtualMachines", "virtualMachines"),
							sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineName"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Restart": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("VirtualMachineId"),
						URISuffix:           pointer.To("/restart"),
					},
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("VirtualMachineId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingTheSegmentsNamedTheSame(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_multiple_segments_same_name.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"BillingPeriodId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftManagement", "Microsoft.Management"),
							sdkModels.NewStaticValueResourceIDSegment("staticManagementGroups", "managementGroups"),
							sdkModels.NewUserSpecifiedResourceIDSegment("managementGroupId", "managementGroupId"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders2", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftBilling", "Microsoft.Billing"),
							sdkModels.NewStaticValueResourceIDSegment("staticBillingPeriods", "billingPeriods"),
							sdkModels.NewUserSpecifiedResourceIDSegment("billingPeriodName", "billingPeriodName"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("BillingPeriodId"),
						URISuffix:           pointer.To("/Microsoft.Consumption/aggregatedCost"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdsWhereTheSameUriContainsDifferentConstantValuesPerOperation(t *testing.T) {
	t.Parallel(
	// Whilst a URI may contain Constants, the values for those constants can differ per HTTP Operation
	// as such we need to ensure that these are output as different Resource ID types
	//
	// In this case there are 2 constants defined, `PlanetNames` and `PlanetEarth` - however `PlanetEarth` is a constant
	// with a single value - therefore `PlanetEarth` will be removed.
	// The Operation `HEAD /galaxies/{galaxyName}/hello/{planetName}` should remain as-is
	// The Operation `DELETE /galaxies/{galaxyName}/hello/{planetName}` should be transformed to `/galaxies/{galaxyName}/hello/Earth`
	// This means we should end up with 2 IDs, GalaxyId and PlanetId (with Earth and Mars the Constant PlanetNames in PlanetId)
	//
	// Experience has shown this is eventually consistent, maybe 100x is overkill, but it'll do for now.
	)

	for i := 0; i < 100; i++ {
		t.Logf("iteration %d", i)

		actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_same_uri_different_constant_values_per_operation.json", nil)
		if err != nil {
			t.Fatalf("parsing: %+v", err)
		}

		expected := sdkModels.APIVersion{
			APIVersion: "2020-01-01",
			Resources: map[string]sdkModels.APIResource{
				"Hello": {
					Constants: map[string]sdkModels.SDKConstant{
						"PlanetNames": {
							Type: sdkModels.StringSDKConstantType,
							Values: map[string]string{
								"Earth": "Earth",
								"Mars":  "Mars",
							},
						},
					},
					ResourceIDs: map[string]sdkModels.ResourceID{
						"GalaxyId": {
							Segments: []sdkModels.ResourceIDSegment{
								sdkModels.NewStaticValueResourceIDSegment("staticGalaxies", "galaxies"),
								sdkModels.NewUserSpecifiedResourceIDSegment("galaxyName", "galaxyName"),
							},
						},
						"PlanetId": {
							ConstantNames: []string{
								"PlanetNames",
							},
							Segments: []sdkModels.ResourceIDSegment{
								sdkModels.NewStaticValueResourceIDSegment("staticGalaxies", "galaxies"),
								sdkModels.NewUserSpecifiedResourceIDSegment("galaxyName", "galaxyName"),
								sdkModels.NewStaticValueResourceIDSegment("staticHello", "hello"),
								sdkModels.NewConstantResourceIDSegment("planetName", "PlanetNames", "Earth"),
							},
						},
					},
					Operations: map[string]sdkModels.SDKOperation{
						"Delete": {
							ContentType:         "application/json",
							ExpectedStatusCodes: []int{200},
							Method:              "DELETE",
							ResourceIDName:      pointer.To("GalaxyId"),
							URISuffix:           pointer.To("/hello/Earth"),
						},
						"Head": {
							ContentType:         "application/json",
							ExpectedStatusCodes: []int{200},
							Method:              "HEAD",
							ResourceIDName:      pointer.To("PlanetId"),
						},
					},
				},
			},
		}
		testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
	}
}

func TestParseResourceIdsCommon(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "resource_ids_common.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ManagementGroupId": {
						CommonIDAlias: pointer.To("ManagementGroup"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
							sdkModels.NewStaticValueResourceIDSegment("managementGroups", "managementGroups"),
							sdkModels.NewUserSpecifiedResourceIDSegment("groupId", "groupId"),
						},
					},
					"ResourceGroupId": {
						CommonIDAlias: pointer.To("ResourceGroup"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
						},
					},
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewScopeResourceIDSegment("scope"),
						},
					},
					"SubscriptionId": {
						CommonIDAlias: pointer.To("Subscription"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
						},
					},
					"UserAssignedIdentityId": {
						CommonIDAlias: pointer.To("UserAssignedIdentity"),
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.ManagedIdentity"),
							sdkModels.NewStaticValueResourceIDSegment("userAssignedIdentities", "userAssignedIdentities"),
							sdkModels.NewUserSpecifiedResourceIDSegment("userAssignedIdentityName", "userAssignedIdentityName"),
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"GetManagementGroup": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ManagementGroupId"),
					},
					"GetResourceGroup": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ResourceGroupId"),
					},
					"GetScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ScopeId"),
					},
					"GetSubscription": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("SubscriptionId"),
					},
					"GetUserAssignedIdentity": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("UserAssignedIdentityId"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}
