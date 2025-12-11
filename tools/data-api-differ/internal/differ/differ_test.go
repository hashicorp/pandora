// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// These tests check the Differ's main code path for each Data Source (e.g. Resource Manager)
// the specific Changes are tested in the subcomponents (e.g. `differ_services.go`) so these
// are high-level tests to ensure we're touching the main code paths, rather than necessarily
// testing every bit of functionality.

func TestDiff_ResourceManager_NoChanges(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				Generate:         true,
				ResourceProvider: pointer.To("Microsoft.Computer"),
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Generate: true,
						Preview:  false,
						Resources: map[string]models.APIResource{
							"VirtualMachines": {
								Constants:   make(map[string]models.SDKConstant),
								Models:      make(map[string]models.SDKModel),
								ResourceIDs: make(map[string]models.ResourceID),
								Operations: map[string]models.SDKOperation{
									"Example": {
										URISuffix: pointer.To("/doSomething"),
									},
								},
							},
						},
						Source: models.HandWrittenSourceDataOrigin,
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				Generate:         true,
				ResourceProvider: pointer.To("Microsoft.Computer"),
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Generate: true,
						Preview:  false,
						Resources: map[string]models.APIResource{
							"VirtualMachines": {
								Constants:   make(map[string]models.SDKConstant),
								Models:      make(map[string]models.SDKModel),
								ResourceIDs: make(map[string]models.ResourceID),
								Operations: map[string]models.SDKOperation{
									"Example": {
										URISuffix: pointer.To("/doSomething"),
									},
								},
							},
						},
						Source: models.HandWrittenSourceDataOrigin,
					},
				},
			},
		},
	}
	expected := make([]changes.Change, 0)
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ServiceAdded(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			// intentionally empty
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {},
		},
	}
	expected := []changes.Change{
		changes.ServiceAdded{
			ServiceName: "Computer",
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ServiceRemoved(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			// intentionally empty
		},
	}
	expected := []changes.Change{
		changes.ServiceRemoved{
			ServiceName: "Computer",
		},
	}
	containsBreakingChanges := true
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ApiVersionAdded(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {},
					"2022-01-01": {},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ApiVersionAdded{
			ServiceName: "Computer",
			ApiVersion:  "2022-01-01",
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ApiVersionRemoved(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {},
					"2022-01-01": {},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ApiVersionRemoved{
			ServiceName: "Computer",
			ApiVersion:  "2022-01-01",
		},
	}
	containsBreakingChanges := true
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ApiResourceAdded(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {},
							"OnPremise": {},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ApiResourceAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "OnPremise",
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ApiResourceRemoved(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {},
							"OnPremise": {},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ApiResourceRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "OnPremise",
		},
	}
	containsBreakingChanges := true
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ConstantAdded(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Constants: map[string]models.SDKConstant{
									"Skus": {},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Constants: map[string]models.SDKConstant{
									"NetworkPerformance": {
										Type: models.StringSDKConstantType,
										Values: map[string]string{
											"First":  "Value",
											"Second": "OtherValue",
										},
									},
									"Skus": {},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ConstantAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Instances",
			ConstantName: "NetworkPerformance",
			ConstantType: string(models.StringSDKConstantType),
			KeysAndValues: map[string]string{
				"First":  "Value",
				"Second": "OtherValue",
			},
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ConstantRemoved(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Constants: map[string]models.SDKConstant{
									"NetworkPerformance": {
										Type: models.StringSDKConstantType,
										Values: map[string]string{
											"First":  "Value",
											"Second": "OtherValue",
										},
									},
									"Skus": {},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Constants: map[string]models.SDKConstant{
									"Skus": {},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ConstantRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Instances",
			ConstantName: "NetworkPerformance",
			ConstantType: string(models.StringSDKConstantType),
			KeysAndValues: map[string]string{
				"First":  "Value",
				"Second": "OtherValue",
			},
		},
	}
	containsBreakingChanges := true
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ModelAdded(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Models: map[string]models.SDKModel{
									"VirtualMachine": {},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Models: map[string]models.SDKModel{
									"PhysicalMachine": {},
									"VirtualMachine":  {},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ModelAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Instances",
			ModelName:    "PhysicalMachine",
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ModelRemoved(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Models: map[string]models.SDKModel{
									"PhysicalMachine": {},
									"VirtualMachine":  {},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Models: map[string]models.SDKModel{
									"VirtualMachine": {},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ModelRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Instances",
			ModelName:    "PhysicalMachine",
		},
	}
	containsBreakingChanges := true
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_FieldAdded(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Models: map[string]models.SDKModel{
									"PhysicalMachine": {
										Fields: map[string]models.SDKField{
											"First": {
												ObjectDefinition: models.SDKObjectDefinition{
													Type: models.StringSDKObjectDefinitionType,
												},
											},
										},
									},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Models: map[string]models.SDKModel{
									"PhysicalMachine": {
										Fields: map[string]models.SDKField{
											"First": {
												ObjectDefinition: models.SDKObjectDefinition{
													Type: models.StringSDKObjectDefinitionType,
												},
											},
											"Second": {
												ObjectDefinition: models.SDKObjectDefinition{
													Type: models.StringSDKObjectDefinitionType,
												},
											},
										},
									},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.FieldAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Instances",
			ModelName:    "PhysicalMachine",
			FieldName:    "Second",
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_FieldRemoved(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Models: map[string]models.SDKModel{
									"PhysicalMachine": {
										Fields: map[string]models.SDKField{
											"First": {
												ObjectDefinition: models.SDKObjectDefinition{
													Type: models.StringSDKObjectDefinitionType,
												},
											},
											"Second": {
												ObjectDefinition: models.SDKObjectDefinition{
													Type: models.StringSDKObjectDefinitionType,
												},
											},
										},
									},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Models: map[string]models.SDKModel{
									"PhysicalMachine": {
										Fields: map[string]models.SDKField{
											"First": {
												ObjectDefinition: models.SDKObjectDefinition{
													Type: models.StringSDKObjectDefinitionType,
												},
											},
										},
									},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.FieldRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Instances",
			ModelName:    "PhysicalMachine",
			FieldName:    "Second",
		},
	}
	containsBreakingChanges := true
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_OperationAdded(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Operations: map[string]models.SDKOperation{
									"First": {
										URISuffix: pointer.To("/hello"),
									},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Operations: map[string]models.SDKOperation{
									"First": {
										URISuffix: pointer.To("/hello"),
									},
									"Second": {
										URISuffix: pointer.To("/world"),
									},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.OperationAdded{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Instances",
			OperationName: "Second",
			Uri:           "/world",
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_OperationRemoved(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Operations: map[string]models.SDKOperation{
									"First": {
										URISuffix: pointer.To("/hello"),
									},
									"Second": {
										URISuffix: pointer.To("/world"),
									},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								Operations: map[string]models.SDKOperation{
									"First": {
										URISuffix: pointer.To("/hello"),
									},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.OperationRemoved{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Instances",
			OperationName: "Second",
			Uri:           "/world",
		},
	}
	containsBreakingChanges := true
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ResourceIdAdded(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								ResourceIDs: make(map[string]models.ResourceID),
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								ResourceIDs: map[string]models.ResourceID{
									"First": {
										ExampleValue: "/example",
										Segments: []models.ResourceIDSegment{
											models.NewStaticValueResourceIDSegment("staticExample", "example"),
										},
									},
								},
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ResourceIdAdded{
			ServiceName:     "Computer",
			ApiVersion:      "2020-01-01",
			ResourceName:    "Instances",
			ResourceIdName:  "First",
			ResourceIdValue: "/example",
			StaticIdentifiersInNewValue: []string{
				"example",
			},
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ResourceIdRemoved(t *testing.T) {
	initial := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								ResourceIDs: map[string]models.ResourceID{
									"First": {
										ExampleValue: "/example",
									},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := v1.LoadAllDataResult{
		Services: map[string]models.Service{
			"Computer": {
				APIVersions: map[string]models.APIVersion{
					"2020-01-01": {
						Resources: map[string]models.APIResource{
							"Instances": {
								ResourceIDs: make(map[string]models.ResourceID),
							},
						},
					},
				},
			},
		},
	}
	expected := []changes.Change{
		changes.ResourceIdRemoved{
			ServiceName:     "Computer",
			ApiVersion:      "2020-01-01",
			ResourceName:    "Instances",
			ResourceIdName:  "First",
			ResourceIdValue: "/example",
		},
	}
	containsBreakingChanges := true
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}
