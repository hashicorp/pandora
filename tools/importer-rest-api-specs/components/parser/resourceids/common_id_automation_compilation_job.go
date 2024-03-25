// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdAutomationCompilationJob{}

type commonIdAutomationCompilationJob struct{}

func (c commonIdAutomationCompilationJob) id() models.ResourceID {
	name := "AutomationCompilationJob"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Automation"),
			models.NewStaticValueResourceIDSegment("automationAccounts", "automationAccounts"),
			models.NewUserSpecifiedResourceIDSegment("automationAccountName", "automationAccountName"),
			models.NewStaticValueResourceIDSegment("compilationJobs", "compilationJobs"),
			models.NewUserSpecifiedResourceIDSegment("compilationJobId", "compilationJobId"),
		},
	}
}
