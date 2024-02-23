// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdSqlDatabase{}

type commonIdSqlDatabase struct{}

func (c commonIdSqlDatabase) id() models.ResourceID {
	name := "SqlDatabase"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Sql"),
			models.NewStaticValueResourceIDSegment("servers", "servers"),
			models.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
			models.NewStaticValueResourceIDSegment("databases", "databases"),
			models.NewUserSpecifiedResourceIDSegment("databaseName", "databaseName"),
		},
	}
}
