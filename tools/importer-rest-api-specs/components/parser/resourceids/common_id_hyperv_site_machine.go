// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdHyperVSiteMachine{}

type commonIdHyperVSiteMachine struct{}

func (c commonIdHyperVSiteMachine) id() models.ResourceID {
	name := "HyperVSiteMachine"
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
			models.NewStaticValueResourceIDSegment("machines", "machines"),
			models.NewUserSpecifiedResourceIDSegment("machineName", "machineName"),
		},
	}
}
