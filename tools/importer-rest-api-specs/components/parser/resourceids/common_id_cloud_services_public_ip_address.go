package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdCloudServicesPublicIPAddress{}

type commonIdCloudServicesPublicIPAddress struct{}

func (c commonIdCloudServicesPublicIPAddress) id() models.ParsedResourceId {
	name := "CloudServicesPublicIPAddress"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Compute"),
			models.StaticResourceIDSegment("cloudServices", "cloudServices"),
			models.UserSpecifiedResourceIDSegment("cloudServiceName"),
			models.StaticResourceIDSegment("roleInstances", "roleInstances"),
			models.UserSpecifiedResourceIDSegment("roleInstanceName"),
			models.StaticResourceIDSegment("networkInterfaces", "networkInterfaces"),
			models.UserSpecifiedResourceIDSegment("networkInterfaceName"),
			models.StaticResourceIDSegment("ipConfigurations", "ipConfigurations"),
			models.UserSpecifiedResourceIDSegment("ipConfigurationName"),
			models.StaticResourceIDSegment("publicIPAddresses", "publicIPAddresses"),
			models.UserSpecifiedResourceIDSegment("publicIPAddressName"),
		},
	}

}
