// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdKustoDatabase{}

type commonIdKustoDatabase struct{}

func (c commonIdKustoDatabase) ID() sdkModels.ResourceID {
	name := "KustoDatabase"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftKusto", "Microsoft.Kusto"),
			sdkModels.NewStaticValueResourceIDSegment("staticClusters", "clusters"),
			sdkModels.NewUserSpecifiedResourceIDSegment("kustoClusterName", "kustoClusterName"),
			sdkModels.NewStaticValueResourceIDSegment("staticDatabases", "databases"),
			sdkModels.NewUserSpecifiedResourceIDSegment("kustoDatabaseName", "kustoDatabaseName"),
		},
	}
}
