// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdChaosStudioCapability{}

type commonIdChaosStudioCapability struct{}

func (commonIdChaosStudioCapability) id() importerModels.ParsedResourceId {
	name := "ChaosStudioCapability"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.ScopeResourceIDSegment("scope"),
			importerModels.StaticResourceIDSegment("staticProviders", "providers"),
			importerModels.ResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			importerModels.StaticResourceIDSegment("staticTargets", "targets"),
			importerModels.UserSpecifiedResourceIDSegment("targetName"),
			importerModels.StaticResourceIDSegment("staticCapabilities", "capabilities"),
			importerModels.UserSpecifiedResourceIDSegment("capabilityName"),
		},
	}
}
