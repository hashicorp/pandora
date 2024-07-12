// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdChaosStudioTarget{}

type commonIdChaosStudioTarget struct{}

func (commonIdChaosStudioTarget) ID() sdkModels.ResourceID {
	name := "ChaosStudioTarget"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewScopeResourceIDSegment("scope"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			sdkModels.NewStaticValueResourceIDSegment("staticTargets", "targets"),
			sdkModels.NewUserSpecifiedResourceIDSegment("targetName", "targetName"),
		},
	}
}
