using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualNetworks;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(TransportProtocolConstant),
        typeof(UsagePermissionTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExternalSubnetModel),
        typeof(PortModel),
        typeof(SubnetModel),
        typeof(SubnetOverrideModel),
        typeof(SubnetSharedPublicIPAddressConfigurationModel),
        typeof(UpdateResourceModel),
        typeof(VirtualNetworkModel),
        typeof(VirtualNetworkPropertiesModel),
    };
}
