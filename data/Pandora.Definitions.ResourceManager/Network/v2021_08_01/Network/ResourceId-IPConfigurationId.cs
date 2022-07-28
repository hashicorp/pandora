using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;

internal class IPConfigurationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftCompute", "Microsoft.Compute"),
        ResourceIDSegment.Static("staticVirtualMachineScaleSets", "virtualMachineScaleSets"),
        ResourceIDSegment.UserSpecified("virtualMachineScaleSetName"),
        ResourceIDSegment.Static("staticVirtualMachines", "virtualMachines"),
        ResourceIDSegment.UserSpecified("virtualmachineIndex"),
        ResourceIDSegment.Static("staticNetworkInterfaces", "networkInterfaces"),
        ResourceIDSegment.UserSpecified("networkInterfaceName"),
        ResourceIDSegment.Static("staticIpconfigurations", "ipconfigurations"),
        ResourceIDSegment.UserSpecified("ipConfigurationName"),
    };
}
