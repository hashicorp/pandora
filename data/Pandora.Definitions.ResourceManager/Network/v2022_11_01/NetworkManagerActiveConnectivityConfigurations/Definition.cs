using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.NetworkManagerActiveConnectivityConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkManagerActiveConnectivityConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListActiveConnectivityConfigurationsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectivityTopologyConstant),
        typeof(DeleteExistingPeeringConstant),
        typeof(GroupConnectivityConstant),
        typeof(IsGlobalConstant),
        typeof(ProvisioningStateConstant),
        typeof(UseHubGatewayConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActiveConfigurationParameterModel),
        typeof(ActiveConnectivityConfigurationModel),
        typeof(ActiveConnectivityConfigurationsListResultModel),
        typeof(ConfigurationGroupModel),
        typeof(ConnectivityConfigurationPropertiesModel),
        typeof(ConnectivityGroupItemModel),
        typeof(HubModel),
        typeof(NetworkGroupPropertiesModel),
    };
}
