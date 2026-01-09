// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdSqlElasticPool{}

type commonIdSqlElasticPool struct{}

func (c commonIdSqlElasticPool) ID() sdkModels.ResourceID {
	name := "SqlElasticPool"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Sql"),
			sdkModels.NewStaticValueResourceIDSegment("servers", "servers"),
			sdkModels.NewUserSpecifiedResourceIDSegment("serverName", "serverName"),
			sdkModels.NewStaticValueResourceIDSegment("elasticPools", "elasticPools"),
			sdkModels.NewUserSpecifiedResourceIDSegment("elasticPoolName", "elasticPoolName"),
		},
	}
}
