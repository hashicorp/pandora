// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdChaosStudioTarget{}

type commonIdChaosStudioTarget struct{}

func (commonIdChaosStudioTarget) id() importerModels.ParsedResourceId {
	name := "ChaosStudioTarget"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.ScopeResourceIDSegment("scope"),
			importerModels.StaticResourceIDSegment("staticProviders", "providers"),
			importerModels.ResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			importerModels.StaticResourceIDSegment("staticTargets", "targets"),
			importerModels.UserSpecifiedResourceIDSegment("targetName"),
		},
	}
}
