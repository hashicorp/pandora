// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdSpringCloudService{}

type commonIdSpringCloudService struct{}

func (c commonIdSpringCloudService) id() models.ResourceID {
	name := "SpringCloudService"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftAppPlatform", "Microsoft.AppPlatform"),
			models.NewStaticValueResourceIDSegment("staticSpring", "spring"),
			models.NewUserSpecifiedResourceIDSegment("serviceName", "serviceName"),
		},
	}
}
