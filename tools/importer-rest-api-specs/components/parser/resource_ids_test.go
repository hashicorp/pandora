// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseResourceIdBasic(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_basic.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ServerId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							models.NewStaticValueResourceIDSegment("staticServers", "servers"),
							models.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ServerId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAConstant(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_containing_constant.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"Planet": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"Earth":   "Earth",
							"Jupiter": "Jupiter",
							"Mars":    "Mars",
							"Saturn":  "Saturn",
						},
					},
				},
				ResourceIds: map[string]models.ResourceID{
					"PlanetId": {
						ConstantNames: []string{
							"Planet",
						},
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticPlanets", "planets"),
							models.NewConstantResourceIDSegment("planetName", "Planet", "Earth"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"OperationContainingAConstant": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("PlanetId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAScope(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_containing_scope.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ScopedVirtualMachineId": {
						Segments: []models.ResourceIDSegment{
							models.NewScopeResourceIDSegment("scope"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							models.NewStaticValueResourceIDSegment("staticVirtualMachines", "virtualMachines"),
							models.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachinesName"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"OperationContainingAScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ScopedVirtualMachineId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAHiddenScope(t *testing.T) {
	files := []string{
		"resource_ids_containing_hidden_scope.json",
		"resource_ids_containing_hidden_scope_constant.json",
		"resource_ids_containing_hidden_scope_hardcoded_provider.json",
	}
	for _, file := range files {
		t.Run(file, func(t *testing.T) {
			fileName := file

			actual, err := ParseSwaggerFileForTesting(t, fileName)
			if err != nil {
				t.Fatalf("parsing: %+v", err)
			}

			expected := importerModels.AzureApiDefinition{
				ServiceName: "Example",
				ApiVersion:  "2020-01-01",
				Resources: map[string]importerModels.AzureApiResource{
					"Example": {
						ResourceIds: map[string]models.ResourceID{
							"ScopeId": {
								CommonIDAlias: pointer.To("Scope"),
								Segments: []models.ResourceIDSegment{
									models.NewScopeResourceIDSegment("scope"),
								},
							},
						},
						Operations: map[string]importerModels.OperationDetails{
							"OperationContainingAHiddenScope": {
								ContentType:         "application/json",
								ExpectedStatusCodes: []int{200},
								Method:              "HEAD",
								ResourceIdName:      pointer.To("ScopeId"),
							},
						},
					},
				},
			}
			validateParsedSwaggerResultMatches(t, expected, actual)
		})
	}
}

func TestParseResourceIdContainingAHiddenScopeWithExtraSegment(t *testing.T) {
	// The extra segment should be ignored and detected as a regular scope
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_containing_hidden_scope_with_extra_segment.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []models.ResourceIDSegment{
							models.NewScopeResourceIDSegment("scope"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"OperationContainingAHiddenScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ScopeId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAHiddenScopeWithSuffix(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_containing_hidden_scope_with_suffix.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []models.ResourceIDSegment{
							models.NewScopeResourceIDSegment("scope"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"OperationContainingAHiddenScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ScopeId"),
						UriSuffix:           pointer.To("/someEndpoint"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAHiddenScopeNested(t *testing.T) {
	files := []string{
		"resource_ids_containing_hidden_scope_nested.json",
		"resource_ids_containing_hidden_scope_nested_constants.json",
		"resource_ids_containing_hidden_scope_nested_hardcoded_provider.json",
	}
	for _, file := range files {
		t.Run(file, func(t *testing.T) {
			fileName := file

			actual, err := ParseSwaggerFileForTesting(t, fileName)
			if err != nil {
				t.Fatalf("parsing: %+v", err)
			}

			expected := importerModels.AzureApiDefinition{
				ServiceName: "Example",
				ApiVersion:  "2020-01-01",
				Resources: map[string]importerModels.AzureApiResource{
					"Example": {
						ResourceIds: map[string]models.ResourceID{
							"ScopeId": {
								CommonIDAlias: pointer.To("Scope"),
								Segments: []models.ResourceIDSegment{
									models.NewScopeResourceIDSegment("scope"),
								},
							},
						},
						Operations: map[string]importerModels.OperationDetails{
							"OperationContainingAHiddenScope": {
								ContentType:         "application/json",
								ExpectedStatusCodes: []int{200},
								Method:              "HEAD",
								ResourceIdName:      pointer.To("ScopeId"),
							},
						},
					},
				},
			}
			validateParsedSwaggerResultMatches(t, expected, actual)
		})
	}
}

func TestParseResourceIdContainingAHiddenScopeNestedWithExtraSegment(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_containing_hidden_scope_nested_with_extra_segment.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []models.ResourceIDSegment{
							models.NewScopeResourceIDSegment("scope"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"OperationContainingAHiddenScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ScopeId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingAHiddenScopeNestedWithSuffix(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_containing_hidden_scope_nested_with_suffix.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []models.ResourceIDSegment{
							models.NewScopeResourceIDSegment("scope"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"OperationContainingAHiddenScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ScopeId"),
						UriSuffix:           pointer.To("/someEndpoint"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdWithJustUriSuffix(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_with_just_suffix.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Operations: map[string]importerModels.OperationDetails{
					"JustSuffix": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						UriSuffix:           pointer.To("/restart"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdWithResourceIdAndUriSuffix(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_with_suffix.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ServerId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							models.NewStaticValueResourceIDSegment("staticServers", "servers"),
							models.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ServerId"),
						UriSuffix:           pointer.To("/someOperation"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdWithResourceIdAndUriSuffixForMultipleUris(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_with_suffix_multiple_uris.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ServerId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							models.NewStaticValueResourceIDSegment("staticServers", "servers"),
							models.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Restart": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ServerId"),
						UriSuffix:           pointer.To("/restart"),
					},
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ServerId"),
						UriSuffix:           pointer.To("/someOperation"),
					},
					"TopLevel": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ServerId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingResourceProviderShouldGetTitleCased(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_lowercased_resource_provider.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ServerId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							models.NewStaticValueResourceIDSegment("staticServers", "servers"),
							models.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ServerId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingTheSameResourceIdWithDifferentSegments(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_same_id_different_segment_casing.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"VirtualMachineId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftSomeResourceProvider", "Microsoft.SomeResourceProvider"),
							models.NewStaticValueResourceIDSegment("staticVirtualMachines", "virtualMachines"),
							models.NewUserSpecifiedResourceIDSegment("machineName", "machineName"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Restart": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("VirtualMachineId"),
						UriSuffix:           pointer.To("/restart"),
					},
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("VirtualMachineId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdContainingTheSegmentsNamedTheSame(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_multiple_segments_same_name.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"BillingPeriodId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftManagement", "Microsoft.Management"),
							models.NewStaticValueResourceIDSegment("staticManagementGroups", "managementGroups"),
							models.NewUserSpecifiedResourceIDSegment("managementGroupId", "managementGroupId"),
							models.NewStaticValueResourceIDSegment("staticProviders2", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftBilling", "Microsoft.Billing"),
							models.NewStaticValueResourceIDSegment("staticBillingPeriods", "billingPeriods"),
							models.NewUserSpecifiedResourceIDSegment("billingPeriodName", "billingPeriodName"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("BillingPeriodId"),
						UriSuffix:           pointer.To("/Microsoft.Consumption/aggregatedCost"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseResourceIdsWhereTheSameUriContainsDifferentConstantValuesPerOperation(t *testing.T) {
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
	for i := 0; i < 100; i++ {
		t.Logf("iteration %d", i)

		actual, err := ParseSwaggerFileForTesting(t, "resource_ids_same_uri_different_constant_values_per_operation.json")
		if err != nil {
			t.Fatalf("parsing: %+v", err)
		}

		expected := importerModels.AzureApiDefinition{
			ServiceName: "Example",
			ApiVersion:  "2020-01-01",
			Resources: map[string]importerModels.AzureApiResource{
				"Hello": {
					Constants: map[string]models.SDKConstant{
						"PlanetNames": {
							Type: models.StringSDKConstantType,
							Values: map[string]string{
								"Earth": "Earth",
								"Mars":  "Mars",
							},
						},
					},
					ResourceIds: map[string]models.ResourceID{
						"GalaxyId": {
							Segments: []models.ResourceIDSegment{
								models.NewStaticValueResourceIDSegment("staticGalaxies", "galaxies"),
								models.NewUserSpecifiedResourceIDSegment("galaxyName", "galaxyName"),
							},
						},
						"PlanetId": {
							ConstantNames: []string{
								"PlanetNames",
							},
							Segments: []models.ResourceIDSegment{
								models.NewStaticValueResourceIDSegment("staticGalaxies", "galaxies"),
								models.NewUserSpecifiedResourceIDSegment("galaxyName", "galaxyName"),
								models.NewStaticValueResourceIDSegment("staticHello", "hello"),
								models.NewConstantResourceIDSegment("planetName", "PlanetNames", "Earth"),
							},
						},
					},
					Operations: map[string]importerModels.OperationDetails{
						"Delete": {
							ContentType:         "application/json",
							ExpectedStatusCodes: []int{200},
							Method:              "DELETE",
							ResourceIdName:      pointer.To("GalaxyId"),
							UriSuffix:           pointer.To("/hello/Earth"),
						},
						"Head": {
							ContentType:         "application/json",
							ExpectedStatusCodes: []int{200},
							Method:              "HEAD",
							ResourceIdName:      pointer.To("PlanetId"),
						},
					},
				},
			},
		}
		validateParsedSwaggerResultMatches(t, expected, actual)
	}
}

func TestParseResourceIdsCommon(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "resource_ids_common.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				ResourceIds: map[string]models.ResourceID{
					"ManagementGroupId": {
						CommonIDAlias: pointer.To("ManagementGroup"),
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("providers", "providers"),
							models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
							models.NewStaticValueResourceIDSegment("managementGroups", "managementGroups"),
							models.NewUserSpecifiedResourceIDSegment("groupId", "groupId"),
						},
					},
					"ResourceGroupId": {
						CommonIDAlias: pointer.To("ResourceGroup"),
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
						},
					},
					"ScopeId": {
						CommonIDAlias: pointer.To("Scope"),
						Segments: []models.ResourceIDSegment{
							models.NewScopeResourceIDSegment("scope"),
						},
					},
					"SubscriptionId": {
						CommonIDAlias: pointer.To("Subscription"),
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
						},
					},
					"UserAssignedIdentityId": {
						CommonIDAlias: pointer.To("UserAssignedIdentity"),
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("providers", "providers"),
							models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.ManagedIdentity"),
							models.NewStaticValueResourceIDSegment("userAssignedIdentities", "userAssignedIdentities"),
							models.NewUserSpecifiedResourceIDSegment("userAssignedIdentityName", "userAssignedIdentityName"),
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"GetManagementGroup": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ManagementGroupId"),
					},
					"GetResourceGroup": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ResourceGroupId"),
					},
					"GetScope": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("ScopeId"),
					},
					"GetSubscription": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("SubscriptionId"),
					},
					"GetUserAssignedIdentity": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIdName:      pointer.To("UserAssignedIdentityId"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
