package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdVirtualHubBGPConnection{}

type commonIdVirtualHubBGPConnection struct{}

func (c commonIdVirtualHubBGPConnection) id() models.ParsedResourceId {
	name := "VirtualHubBGPConnection"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			models.StaticResourceIDSegment("virtualHubs", "virtualHubs"),
			models.UserSpecifiedResourceIDSegment("hubName"),
			models.StaticResourceIDSegment("bgpConnections", "bgpConnections"),
			models.UserSpecifiedResourceIDSegment("connectionName"),
		},
	}
}
