// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdHyperVSiteRunAsAccount{}

type commonIdHyperVSiteRunAsAccount struct{}

func (c commonIdHyperVSiteRunAsAccount) ID() sdkModels.ResourceID {
	name := "HyperVSiteRunAsAccount"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.OffAzure"),
			sdkModels.NewStaticValueResourceIDSegment("hyperVSites", "hyperVSites"),
			sdkModels.NewUserSpecifiedResourceIDSegment("hyperVSiteName", "hyperVSiteName"),
			sdkModels.NewStaticValueResourceIDSegment("runAsAccounts", "runAsAccounts"),
			sdkModels.NewUserSpecifiedResourceIDSegment("runAsAccountName", "runAsAccountName"),
		},
	}
}
