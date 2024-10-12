// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVMwareSiteJob{}

type commonIdVMwareSiteJob struct {
}

func (c commonIdVMwareSiteJob) ID() sdkModels.ResourceID {
	name := "VMwareSiteJob"
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
			sdkModels.NewStaticValueResourceIDSegment("jobs", "jobs"),
			sdkModels.NewUserSpecifiedResourceIDSegment("jobName", "jobName"),
		},
	}
}
