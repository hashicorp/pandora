// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVMwareSiteMachine{}

type commonIdVMwareSiteMachine struct {
}

func (c commonIdVMwareSiteMachine) ID() sdkModels.ResourceID {
	name := "VMwareSiteMachine"
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
			sdkModels.NewStaticValueResourceIDSegment("machines", "machines"),
			sdkModels.NewUserSpecifiedResourceIDSegment("machineName", "machineName"),
		},
	}
}
