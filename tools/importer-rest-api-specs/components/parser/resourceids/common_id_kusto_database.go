// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdKustoDatabase{}

type commonIdKustoDatabase struct{}

func (c commonIdKustoDatabase) id() importerModels.ParsedResourceId {
	name := "KustoDatabase"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("staticSubscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("staticResourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("staticProviders", "providers"),
			importerModels.ResourceProviderResourceIDSegment("staticMicrosoftKusto", "Microsoft.Kusto"),
			importerModels.StaticResourceIDSegment("staticClusters", "clusters"),
			importerModels.UserSpecifiedResourceIDSegment("kustoClusterName"),
			importerModels.StaticResourceIDSegment("staticDatabases", "databases"),
			importerModels.UserSpecifiedResourceIDSegment("kustoDatabaseName"),
		},
	}
}
