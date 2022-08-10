package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdVirtualWANP2SVPNGateway{}

type commonIdVirtualWANP2SVPNGateway struct{}

func (c commonIdVirtualWANP2SVPNGateway) id() models.ParsedResourceId {
	name := "VirtualWANP2SVPNGateway"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroup"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			models.StaticResourceIDSegment("p2sVpnGateways", "p2sVpnGateways"),
			models.UserSpecifiedResourceIDSegment("gatewayName"),
		},
	}
}
