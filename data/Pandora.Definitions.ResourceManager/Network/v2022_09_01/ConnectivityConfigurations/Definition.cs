using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.ConnectivityConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "ConnectivityConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
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
        typeof(ConnectivityConfigurationModel),
        typeof(ConnectivityConfigurationPropertiesModel),
        typeof(ConnectivityGroupItemModel),
        typeof(HubModel),
    };
}
