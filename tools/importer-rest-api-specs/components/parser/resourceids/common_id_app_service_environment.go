// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdAppServiceEnvironment{}

type commonIdAppServiceEnvironment struct{}

func (c commonIdAppServiceEnvironment) id() models.ResourceID {
	name := "AppServiceEnvironment"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Web"),
			models.NewStaticValueResourceIDSegment("hostingEnvironments", "hostingEnvironments"),
			models.NewUserSpecifiedResourceIDSegment("hostingEnvironmentName", "hostingEnvironmentName"),
		},
	}
}
