// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdHyperVSiteJob{}

type commonIdHyperVSiteJob struct{}

func (c commonIdHyperVSiteJob) ID() sdkModels.ResourceID {
	name := "HyperVSiteJob"
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
			sdkModels.NewStaticValueResourceIDSegment("jobs", "jobs"),
			sdkModels.NewUserSpecifiedResourceIDSegment("jobName", "jobName"),
		},
	}
}
