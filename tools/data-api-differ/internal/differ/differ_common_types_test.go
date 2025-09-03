// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestDiff_CommonTypesAdded_WithNestedDetails(t *testing.T) {
	initial := map[string]models.CommonTypes{}
	updated := map[string]models.CommonTypes{
		"2020-01-01": {
			Constants: map[string]models.SDKConstant{
				"SomeConst": {
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"First": "first",
					},
				},
			},
			Models: map[string]models.SDKModel{
				"SomeModel": {
					Fields: map[string]models.SDKField{
						"Example": {
							Required: true,
							JsonName: "example",
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
							},
						},
					},
				},
			},
		},
	}
	actual, err := differ{}.changesForCommonTypes(initial, updated, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.CommonTypesApiVersionAdded{
			ApiVersion: "2020-01-01",
		},
		changes.CommonTypesConstantAdded{
			ApiVersion:   "2020-01-01",
			ConstantName: "SomeConst",
			ConstantType: models.StringSDKConstantType,
			KeysAndValues: map[string]string{
				"First": "first",
			},
		},
		changes.CommonTypesModelAdded{
			ApiVersion: "2020-01-01",
			ModelName:  "SomeModel",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesAdded_WithoutNestedDetails(t *testing.T) {
	initial := map[string]models.CommonTypes{}
	updated := map[string]models.CommonTypes{
		"2020-01-01": {
			Constants: map[string]models.SDKConstant{
				"SomeConst": {
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"First": "first",
					},
				},
			},
			Models: map[string]models.SDKModel{
				"SomeModel": {
					Fields: map[string]models.SDKField{
						"Example": {
							Required: true,
							JsonName: "example",
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
							},
						},
					},
				},
			},
		},
	}
	actual, err := differ{}.changesForCommonTypes(initial, updated, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.CommonTypesApiVersionAdded{
			ApiVersion: "2020-01-01",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesRemoved_WithNestedDetails(t *testing.T) {
	initial := map[string]models.CommonTypes{
		"2020-01-01": {
			Constants: map[string]models.SDKConstant{
				"SomeConst": {
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"First": "first",
					},
				},
			},
			Models: map[string]models.SDKModel{
				"SomeModel": {
					Fields: map[string]models.SDKField{
						"Example": {
							Required: true,
							JsonName: "example",
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
							},
						},
					},
				},
			},
		},
	}
	updated := map[string]models.CommonTypes{}
	actual, err := differ{}.changesForCommonTypes(initial, updated, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.CommonTypesApiVersionRemoved{
			ApiVersion: "2020-01-01",
		},
		// NOTE: the Constant and Model being removed won't be surfaced since this is a removal of an APIVersion
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesRemoved_WithoutNestedDetails(t *testing.T) {
	initial := map[string]models.CommonTypes{
		"2020-01-01": {
			Constants: map[string]models.SDKConstant{
				"SomeConst": {
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"First": "first",
					},
				},
			},
			Models: map[string]models.SDKModel{
				"SomeModel": {
					Fields: map[string]models.SDKField{
						"Example": {
							Required: true,
							JsonName: "example",
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
							},
						},
					},
				},
			},
		},
	}
	updated := map[string]models.CommonTypes{}
	actual, err := differ{}.changesForCommonTypes(initial, updated, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.CommonTypesApiVersionRemoved{
			ApiVersion: "2020-01-01",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
