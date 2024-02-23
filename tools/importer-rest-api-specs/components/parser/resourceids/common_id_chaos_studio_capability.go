// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdChaosStudioCapability{}

type commonIdChaosStudioCapability struct{}

func (commonIdChaosStudioCapability) id() importerModels.ParsedResourceId {
	name := "ChaosStudioCapability"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewScopeResourceIDSegment("scope"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			models.NewStaticValueResourceIDSegment("staticTargets", "targets"),
			models.NewUserSpecifiedResourceIDSegment("targetName", "targetName"),
			models.NewStaticValueResourceIDSegment("staticCapabilities", "capabilities"),
			models.NewUserSpecifiedResourceIDSegment("capabilityName", "capabilityName"),
		},
	}
}
