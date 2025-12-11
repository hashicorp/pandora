// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdStorageContainer{}

type commonIdStorageContainer struct{}

func (c commonIdStorageContainer) ID() sdkModels.ResourceID {
	name := "StorageContainer"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Storage"),
			sdkModels.NewStaticValueResourceIDSegment("storageAccounts", "storageAccounts"),
			sdkModels.NewUserSpecifiedResourceIDSegment("storageAccountName", "storageAccountName"),
			sdkModels.NewStaticValueResourceIDSegment("blobServices", "blobServices"),
			sdkModels.NewStaticValueResourceIDSegment("default", "default"),
			sdkModels.NewStaticValueResourceIDSegment("containers", "containers"),
			sdkModels.NewUserSpecifiedResourceIDSegment("containerName", "containerName"),
		},
	}
}
