// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdKustoDatabase{}

type commonIdKustoDatabase struct{}

func (c commonIdKustoDatabase) id() models.ResourceID {
	name := "KustoDatabase"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftKusto", "Microsoft.Kusto"),
			models.NewStaticValueResourceIDSegment("staticClusters", "clusters"),
			models.NewUserSpecifiedResourceIDSegment("kustoClusterName", "kustoClusterName"),
			models.NewStaticValueResourceIDSegment("staticDatabases", "databases"),
			models.NewUserSpecifiedResourceIDSegment("kustoDatabaseName", "kustoDatabaseName"),
		},
	}
}
