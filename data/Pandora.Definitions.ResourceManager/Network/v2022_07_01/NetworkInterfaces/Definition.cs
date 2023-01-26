using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkInterfaces;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkInterfaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEffectiveRouteTableOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListEffectiveNetworkSecurityGroupsOperation(),
        new NetworkInterfaceIPConfigurationsGetOperation(),
        new NetworkInterfaceIPConfigurationsListOperation(),
        new NetworkInterfaceLoadBalancersListOperation(),
        new NetworkInterfaceTapConfigurationsGetOperation(),
        new NetworkInterfaceTapConfigurationsListOperation(),
        new UpdateTagsOperation(),
    };
}
