// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdKustoDatabase{}

type commonIdKustoDatabase struct{}

func (c commonIdKustoDatabase) id() models.ParsedResourceId {
	name := "KustoDatabase"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("staticProviders", "providers"),
			models.ResourceProviderResourceIDSegment("staticMicrosoftKusto", "Microsoft.Kusto"),
			models.StaticResourceIDSegment("staticClusters", "clusters"),
			models.UserSpecifiedResourceIDSegment("kustoClusterName"),
			models.StaticResourceIDSegment("staticDatabases", "databases"),
			models.UserSpecifiedResourceIDSegment("kustoDatabaseName"),
		},
	}
}
