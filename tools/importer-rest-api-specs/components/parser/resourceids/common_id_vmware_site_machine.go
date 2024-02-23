// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdVMwareSiteMachine{}

type commonIdVMwareSiteMachine struct {
}

func (c commonIdVMwareSiteMachine) id() models.ResourceID {
	name := "VMwareSiteMachine"
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
			models.NewStaticValueResourceIDSegment("vmwareSites", "vmwareSites"),
			models.NewUserSpecifiedResourceIDSegment("vmwareSiteName", "vmwareSiteName"),
			models.NewStaticValueResourceIDSegment("machines", "machines"),
			models.NewUserSpecifiedResourceIDSegment("machineName", "machineName"),
		},
	}
}
