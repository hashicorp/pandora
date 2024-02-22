// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdSqlElasticPool{}

type commonIdSqlElasticPool struct{}

func (c commonIdSqlElasticPool) id() importerModels.ParsedResourceId {
	name := "SqlElasticPool"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Sql"),
			models.NewStaticValueResourceIDSegment("servers", "servers"),
			models.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
			models.NewStaticValueResourceIDSegment("elasticPools", "elasticPools"),
			models.NewUserSpecifiedResourceIDSegment("elasticPoolName", "elasticPoolName"),
		},
	}
}
