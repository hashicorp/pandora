using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkInterfaces;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkInterfaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetCloudServiceNetworkInterfaceOperation(),
        new GetEffectiveRouteTableOperation(),
        new GetVirtualMachineScaleSetIPConfigurationOperation(),
        new GetVirtualMachineScaleSetNetworkInterfaceOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListCloudServiceNetworkInterfacesOperation(),
        new ListCloudServiceRoleInstanceNetworkInterfacesOperation(),
        new ListEffectiveNetworkSecurityGroupsOperation(),
        new ListVirtualMachineScaleSetIPConfigurationsOperation(),
        new ListVirtualMachineScaleSetNetworkInterfacesOperation(),
        new ListVirtualMachineScaleSetVMNetworkInterfacesOperation(),
        new NetworkInterfaceIPConfigurationsGetOperation(),
        new NetworkInterfaceIPConfigurationsListOperation(),
        new NetworkInterfaceLoadBalancersListOperation(),
        new NetworkInterfaceTapConfigurationsGetOperation(),
        new NetworkInterfaceTapConfigurationsListOperation(),
        new UpdateTagsOperation(),
    };
}
