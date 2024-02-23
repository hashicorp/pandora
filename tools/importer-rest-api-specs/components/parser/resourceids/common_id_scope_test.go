// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestCommonResourceID_Scope(t *testing.T) {
	valid := models.ResourceID{
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewScopeResourceIDSegment("resourcePath"),
		},
	}
	invalid := models.ResourceID{
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewScopeResourceIDSegment("scope"),
			models.NewStaticValueResourceIDSegment("someResource", "someResource"),
			models.NewUserSpecifiedResourceIDSegment("resourceName", "resourceName"),
		},
	}
	input := []models.ResourceID{
		valid,
		invalid,
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	for _, actual := range output {
		if ResourceIdsMatch(actual, valid) {
			if actual.CommonIDAlias == nil {
				t.Fatalf("Expected `valid` to have the CommonIDAlias `Scope` but got nil")
			}
			if *actual.CommonIDAlias != "Scope" {
				t.Fatalf("Expected `valid` to have the CommonIDAlias `Scope` but got %q", *actual.CommonIDAlias)
			}

			continue
		}

		if ResourceIdsMatch(actual, invalid) {
			if actual.CommonIDAlias != nil {
				t.Fatalf("Expected `invalid` to have no CommonIDAlias but got %q", *actual.CommonIDAlias)
			}
			continue
		}

		t.Fatalf("unexpected Resource ID %q", normalizedResourceId(actual.Segments))
	}
}
