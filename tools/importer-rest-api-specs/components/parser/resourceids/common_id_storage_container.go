package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdStorageContainer{}

type commonIdStorageContainer struct{}

func (c commonIdStorageContainer) id() models.ParsedResourceId {
	name := "StorageContainer"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Storage"),
			models.StaticResourceIDSegment("storageAccounts", "storageAccounts"),
			models.UserSpecifiedResourceIDSegment("storageAccountName"),
			models.StaticResourceIDSegment("blobServices", "blobServices"),
			models.StaticResourceIDSegment("default", "default"),
			models.StaticResourceIDSegment("containers", "containers"),
			models.UserSpecifiedResourceIDSegment("containerName"),
		},
	}
}
