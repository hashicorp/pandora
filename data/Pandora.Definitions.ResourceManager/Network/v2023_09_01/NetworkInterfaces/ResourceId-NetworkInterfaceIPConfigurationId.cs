using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkInterfaces;

internal class NetworkInterfaceIPConfigurationId : ResourceID
{
    public string? CommonAlias => "NetworkInterfaceIPConfiguration";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkInterfaces/{networkInterfaceName}/ipConfigurations/{ipConfigurationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.Network"),
        ResourceIDSegment.Static("networkInterfaces", "networkInterfaces"),
        ResourceIDSegment.UserSpecified("networkInterfaceName"),
        ResourceIDSegment.Static("ipConfigurations", "ipConfigurations"),
        ResourceIDSegment.UserSpecified("ipConfigurationName"),
    };
}
