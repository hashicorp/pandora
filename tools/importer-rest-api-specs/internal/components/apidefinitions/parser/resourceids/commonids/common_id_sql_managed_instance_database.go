// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdSqlManagedInstanceDatabase{}

type commonIdSqlManagedInstanceDatabase struct{}

func (c commonIdSqlManagedInstanceDatabase) ID() sdkModels.ResourceID {
	name := "SqlManagedInstanceDatabase"
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
			sdkModels.NewStaticValueResourceIDSegment("managedInstances", "managedInstances"),
			sdkModels.NewUserSpecifiedResourceIDSegment("managedInstanceName", "managedInstanceName"),
			sdkModels.NewStaticValueResourceIDSegment("databases", "databases"),
			sdkModels.NewUserSpecifiedResourceIDSegment("databaseName", "databaseName"),
		},
	}
}
