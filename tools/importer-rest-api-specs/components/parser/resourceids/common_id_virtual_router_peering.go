package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdVirtualRouterPeering{}

type commonIdVirtualRouterPeering struct{}

func (c commonIdVirtualRouterPeering) id() models.ParsedResourceId {
	name := "VirtualRouterPeering"
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
			models.StaticResourceIDSegment("virtualRouters", "virtualRouters"),
			models.UserSpecifiedResourceIDSegment("virtualRouterName"),
			models.StaticResourceIDSegment("peerings", "peerings"),
			models.UserSpecifiedResourceIDSegment("peeringName"),
		},
	}

}
