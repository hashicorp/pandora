// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdSqlDatabase{}

type commonIdSqlDatabase struct{}

func (c commonIdSqlDatabase) id() models.ParsedResourceId {
	name := "SqlDatabase"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Sql"),
			models.StaticResourceIDSegment("servers", "servers"),
			models.UserSpecifiedResourceIDSegment("serverName"),
			models.StaticResourceIDSegment("databases", "databases"),
			models.UserSpecifiedResourceIDSegment("databaseName"),
		},
	}
}
