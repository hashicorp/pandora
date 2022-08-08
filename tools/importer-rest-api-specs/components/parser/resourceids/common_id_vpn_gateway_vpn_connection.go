package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdVPNConnection{}

type commonIdVPNConnection struct{}

func (c commonIdVPNConnection) id() models.ParsedResourceId {
	name := "VPNConnection"
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
			models.StaticResourceIDSegment("vpnGateways", "vpnGateways"),
			models.UserSpecifiedResourceIDSegment("gatewayName"),
			models.StaticResourceIDSegment("vpnConnections", "vpnConnections"),
			models.UserSpecifiedResourceIDSegment("connectionName"),
		},
	}
}
