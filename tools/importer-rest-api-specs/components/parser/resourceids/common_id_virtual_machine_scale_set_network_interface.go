package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdVirtualMachineScaleSetNetworkInterface{}

type commonIdVirtualMachineScaleSetNetworkInterface struct{}

func (c commonIdVirtualMachineScaleSetNetworkInterface) id() models.ParsedResourceId {
	name := "VirtualMachineScaleSetNetworkInterface"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroup"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Compute"),
			models.StaticResourceIDSegment("virtualMachineScaleSets", "virtualMachineScaleSets"),
			models.UserSpecifiedResourceIDSegment("virtualMachineScaleSetName"),
			models.StaticResourceIDSegment("virtualMachines", "virtualMachines"),
			models.UserSpecifiedResourceIDSegment("virtualMachineIndex"),
			models.StaticResourceIDSegment("networkInterfaces", "networkInterfaces"),
			models.UserSpecifiedResourceIDSegment("networkInterfaceName"),
		},
	}

}
