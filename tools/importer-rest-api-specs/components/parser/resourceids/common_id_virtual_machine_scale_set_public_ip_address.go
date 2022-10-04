package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdVirtualMachineScaleSetPublicIPAddress{}

type commonIdVirtualMachineScaleSetPublicIPAddress struct{}

func (c commonIdVirtualMachineScaleSetPublicIPAddress) id() models.ParsedResourceId {
	name := "VirtualMachineScaleSetPublicIPAddress"
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
			models.StaticResourceIDSegment("virtualMachineScaleSets", "virtualMachineScaleSets"),
			models.UserSpecifiedResourceIDSegment("virtualMachineScaleSetName"),
			models.StaticResourceIDSegment("virtualMachines", "virtualMachines"),
			models.UserSpecifiedResourceIDSegment("virtualMachineIndex"),
			models.StaticResourceIDSegment("networkInterfaces", "networkInterfaces"),
			models.UserSpecifiedResourceIDSegment("networkInterfaceName"),
			models.StaticResourceIDSegment("ipConfigurations", "ipConfigurations"),
			models.UserSpecifiedResourceIDSegment("ipConfigurationName"),
			models.StaticResourceIDSegment("publicIPAddresses", "publicIPAddresses"),
			models.UserSpecifiedResourceIDSegment("publicIpAddressName"),
		},
	}

}
