// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdSpringCloudService{}

type commonIdSpringCloudService struct{}

func (c commonIdSpringCloudService) id() importerModels.ParsedResourceId {
	name := "SpringCloudService"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("staticSubscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("staticResourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("staticProviders", "providers"),
			importerModels.ResourceProviderResourceIDSegment("staticMicrosoftAppPlatform", "Microsoft.AppPlatform"),
			importerModels.StaticResourceIDSegment("staticSpring", "spring"),
			importerModels.UserSpecifiedResourceIDSegment("serviceName"),
		},
	}
}
