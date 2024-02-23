// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdHyperVSiteRunAsAccount{}

type commonIdHyperVSiteRunAsAccount struct{}

func (c commonIdHyperVSiteRunAsAccount) id() models.ResourceID {
	name := "HyperVSiteRunAsAccount"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.OffAzure"),
			models.NewStaticValueResourceIDSegment("hyperVSites", "hyperVSites"),
			models.NewUserSpecifiedResourceIDSegment("hyperVSiteName", "hyperVSiteName"),
			models.NewStaticValueResourceIDSegment("runAsAccounts", "runAsAccounts"),
			models.NewUserSpecifiedResourceIDSegment("runAsAccountName", "runAsAccountName"),
		},
	}
}
