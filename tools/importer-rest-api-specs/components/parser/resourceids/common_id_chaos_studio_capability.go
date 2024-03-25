// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdChaosStudioCapability{}

type commonIdChaosStudioCapability struct{}

func (commonIdChaosStudioCapability) id() models.ResourceID {
	name := "ChaosStudioCapability"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
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
