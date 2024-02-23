// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdStorageContainer{}

type commonIdStorageContainer struct{}

func (c commonIdStorageContainer) id() importerModels.ParsedResourceId {
	name := "StorageContainer"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("subscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Storage"),
			importerModels.StaticResourceIDSegment("storageAccounts", "storageAccounts"),
			importerModels.UserSpecifiedResourceIDSegment("storageAccountName"),
			importerModels.StaticResourceIDSegment("blobServices", "blobServices"),
			importerModels.StaticResourceIDSegment("default", "default"),
			importerModels.StaticResourceIDSegment("containers", "containers"),
			importerModels.UserSpecifiedResourceIDSegment("containerName"),
		},
	}
}
