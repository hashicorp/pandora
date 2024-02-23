// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdDedicatedHost{}

type commonIdDedicatedHost struct{}

func (c commonIdDedicatedHost) id() importerModels.ParsedResourceId {
	name := "DedicatedHost"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Compute"),
			models.NewStaticValueResourceIDSegment("hostGroups", "hostGroups"),
			models.NewUserSpecifiedResourceIDSegment("hostGroupName", "hostGroupName"),
			models.NewStaticValueResourceIDSegment("hosts", "hosts"),
			models.NewUserSpecifiedResourceIDSegment("hostName", "hostName"),
		},
	}
}
