// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVMwareSiteRunAsAccount{}

type commonIdVMwareSiteRunAsAccount struct {
}

func (c commonIdVMwareSiteRunAsAccount) ID() sdkModels.ResourceID {
	name := "VMwareSiteRunAsAccount"
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
			sdkModels.NewStaticValueResourceIDSegment("vmwareSites", "vmwareSites"),
			sdkModels.NewUserSpecifiedResourceIDSegment("vmwareSiteName", "vmwareSiteName"),
			sdkModels.NewStaticValueResourceIDSegment("runAsAccounts", "runAsAccounts"),
			sdkModels.NewUserSpecifiedResourceIDSegment("runAsAccountName", "runAsAccountName"),
		},
	}
}
