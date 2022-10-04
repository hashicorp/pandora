package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdNetworkInterfaceIPConfiguration{}

type commonIdNetworkInterfaceIPConfiguration struct{}

func (c commonIdNetworkInterfaceIPConfiguration) id() models.ParsedResourceId {
	name := "NetworkInterfaceIPConfiguration"
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
			models.StaticResourceIDSegment("networkInterfaces", "networkInterfaces"),
			models.UserSpecifiedResourceIDSegment("networkInterfaceName"),
			models.StaticResourceIDSegment("ipConfigurations", "ipConfigurations"),
			models.UserSpecifiedResourceIDSegment("ipConfigurationName"),
		},
	}
}
