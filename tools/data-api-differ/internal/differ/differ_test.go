package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// These tests check the Differ's main code path for each Data Source (e.g. Resource Manager)
// the specific Changes are tested in the subcomponents (e.g. `differ_services.go`) so these
// are high-level tests to ensure we're touching the main code paths, rather than necessarily
// testing every bit of functionality.

func TestDiff_ResourceManager_ServiceAdded(t *testing.T) {
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			// intentionally empty
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {},
					"2022-01-01": {},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {},
						},
					},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {},
							"OnPremise": {},
						},
					},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Constants: map[string]resourcemanager.ConstantDetails{
									"Skus": {},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Constants: map[string]resourcemanager.ConstantDetails{
									"NetworkPerformance": {
										Type: resourcemanager.StringConstant,
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
			ConstantType: string(resourcemanager.StringConstant),
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Constants: map[string]resourcemanager.ConstantDetails{
									"NetworkPerformance": {
										Type: resourcemanager.StringConstant,
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
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Constants: map[string]resourcemanager.ConstantDetails{
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
			ConstantType: string(resourcemanager.StringConstant),
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Models: map[string]resourcemanager.ModelDetails{
									"VirtualMachine": {},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Models: map[string]resourcemanager.ModelDetails{
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Models: map[string]resourcemanager.ModelDetails{
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
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Models: map[string]resourcemanager.ModelDetails{
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Models: map[string]resourcemanager.ModelDetails{
									"PhysicalMachine": {
										Fields: map[string]resourcemanager.FieldDetails{
											"First": {
												ObjectDefinition: resourcemanager.ApiObjectDefinition{
													Type: resourcemanager.StringApiObjectDefinitionType,
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
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Models: map[string]resourcemanager.ModelDetails{
									"PhysicalMachine": {
										Fields: map[string]resourcemanager.FieldDetails{
											"First": {
												ObjectDefinition: resourcemanager.ApiObjectDefinition{
													Type: resourcemanager.StringApiObjectDefinitionType,
												},
											},
											"Second": {
												ObjectDefinition: resourcemanager.ApiObjectDefinition{
													Type: resourcemanager.StringApiObjectDefinitionType,
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Models: map[string]resourcemanager.ModelDetails{
									"PhysicalMachine": {
										Fields: map[string]resourcemanager.FieldDetails{
											"First": {
												ObjectDefinition: resourcemanager.ApiObjectDefinition{
													Type: resourcemanager.StringApiObjectDefinitionType,
												},
											},
											"Second": {
												ObjectDefinition: resourcemanager.ApiObjectDefinition{
													Type: resourcemanager.StringApiObjectDefinitionType,
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
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Models: map[string]resourcemanager.ModelDetails{
									"PhysicalMachine": {
										Fields: map[string]resourcemanager.FieldDetails{
											"First": {
												ObjectDefinition: resourcemanager.ApiObjectDefinition{
													Type: resourcemanager.StringApiObjectDefinitionType,
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Operations: map[string]resourcemanager.ApiOperation{
									"First": {
										UriSuffix: pointer.To("/hello"),
									},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Operations: map[string]resourcemanager.ApiOperation{
									"First": {
										UriSuffix: pointer.To("/hello"),
									},
									"Second": {
										UriSuffix: pointer.To("/world"),
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Operations: map[string]resourcemanager.ApiOperation{
									"First": {
										UriSuffix: pointer.To("/hello"),
									},
									"Second": {
										UriSuffix: pointer.To("/world"),
									},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								Operations: map[string]resourcemanager.ApiOperation{
									"First": {
										UriSuffix: pointer.To("/hello"),
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
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								ResourceIds: make(map[string]resourcemanager.ResourceIdDefinition),
							},
						},
					},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
									"First": {
										Id: "/example",
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
		},
	}
	containsBreakingChanges := false
	determineAndValidateDiff(t, initial, updated, expected, containsBreakingChanges)
}

func TestDiff_ResourceManager_ResourceIdRemoved(t *testing.T) {
	initial := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
									"First": {
										Id: "/example",
									},
								},
							},
						},
					},
				},
			},
		},
	}
	updated := dataapi.Data{
		ResourceManagerServices: map[string]dataapi.ServiceData{
			"Computer": {
				ApiVersions: map[string]dataapi.ApiVersionData{
					"2020-01-01": {
						Resources: map[string]dataapi.ApiResourceData{
							"Instances": {
								ResourceIds: make(map[string]resourcemanager.ResourceIdDefinition),
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
