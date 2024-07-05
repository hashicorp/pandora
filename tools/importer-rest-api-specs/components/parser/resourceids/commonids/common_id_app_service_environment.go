// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdAppServiceEnvironment{}

type commonIdAppServiceEnvironment struct{}

func (c commonIdAppServiceEnvironment) ID() sdkModels.ResourceID {
	name := "AppServiceEnvironment"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Web"),
			sdkModels.NewStaticValueResourceIDSegment("hostingEnvironments", "hostingEnvironments"),
			sdkModels.NewUserSpecifiedResourceIDSegment("hostingEnvironmentName", "hostingEnvironmentName"),
		},
	}
}
