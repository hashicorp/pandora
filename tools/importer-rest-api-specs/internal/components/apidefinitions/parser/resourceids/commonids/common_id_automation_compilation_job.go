// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdAutomationCompilationJob{}

type commonIdAutomationCompilationJob struct{}

func (c commonIdAutomationCompilationJob) ID() sdkModels.ResourceID {
	name := "AutomationCompilationJob"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Automation"),
			sdkModels.NewStaticValueResourceIDSegment("automationAccounts", "automationAccounts"),
			sdkModels.NewUserSpecifiedResourceIDSegment("automationAccountName", "automationAccountName"),
			sdkModels.NewStaticValueResourceIDSegment("compilationJobs", "compilationJobs"),
			sdkModels.NewUserSpecifiedResourceIDSegment("compilationJobId", "compilationJobId"),
		},
	}
}
