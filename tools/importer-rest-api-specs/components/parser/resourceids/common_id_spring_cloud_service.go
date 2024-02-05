// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdSpringCloudService{}

type commonIdSpringCloudService struct{}

func (c commonIdSpringCloudService) id() models.ParsedResourceId {
	name := "SpringCloudService"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("staticProviders", "providers"),
			models.ResourceProviderResourceIDSegment("staticMicrosoftAppPlatform", "Microsoft.AppPlatform"),
			models.StaticResourceIDSegment("staticSpring", "spring"),
			models.UserSpecifiedResourceIDSegment("serviceName"),
		},
	}
}
