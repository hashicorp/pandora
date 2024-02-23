// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdStorageContainer{}

type commonIdStorageContainer struct{}

func (c commonIdStorageContainer) id() models.ResourceID {
	name := "StorageContainer"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Storage"),
			models.NewStaticValueResourceIDSegment("storageAccounts", "storageAccounts"),
			models.NewUserSpecifiedResourceIDSegment("storageAccountName", "storageAccountName"),
			models.NewStaticValueResourceIDSegment("blobServices", "blobServices"),
			models.NewStaticValueResourceIDSegment("default", "default"),
			models.NewStaticValueResourceIDSegment("containers", "containers"),
			models.NewUserSpecifiedResourceIDSegment("containerName", "containerName"),
		},
	}
}
