// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdSpringCloudService{}

type commonIdSpringCloudService struct{}

func (c commonIdSpringCloudService) ID() sdkModels.ResourceID {
	name := "SpringCloudService"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftAppPlatform", "Microsoft.AppPlatform"),
			sdkModels.NewStaticValueResourceIDSegment("staticSpring", "spring"),
			sdkModels.NewUserSpecifiedResourceIDSegment("serviceName", "serviceName"),
		},
	}
}
