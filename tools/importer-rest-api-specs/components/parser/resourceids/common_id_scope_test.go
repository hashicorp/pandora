// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestCommonResourceID_Scope(t *testing.T) {
	valid := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.ScopeResourceIDSegment("resourcePath"),
		},
	}
	invalid := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.ScopeResourceIDSegment("scope"),
			importerModels.StaticResourceIDSegment("someResource", "someResource"),
			importerModels.UserSpecifiedResourceIDSegment("resourceName"),
		},
	}
	input := []importerModels.ParsedResourceId{
		valid,
		invalid,
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	for _, actual := range output {
		if actual.Matches(valid) {
			if actual.CommonAlias == nil {
				t.Fatalf("Expected `valid` to have the CommonAlias `Scope` but got nil")
			}
			if *actual.CommonAlias != "Scope" {
				t.Fatalf("Expected `valid` to have the CommonAlias `Scope` but got %q", *actual.CommonAlias)
			}

			continue
		}

		if actual.Matches(invalid) {
			if actual.CommonAlias != nil {
				t.Fatalf("Expected `invalid` to have no CommonAlias but got %q", *actual.CommonAlias)
			}
			continue
		}

		t.Fatalf("unexpected Resource ID %q", normalizedResourceId(actual.Segments))
	}
}
