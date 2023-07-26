using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.VirtualNetworkPeerings;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworkPeerings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(SyncRemoteAddressSpaceConstant),
        typeof(VirtualNetworkEncryptionEnforcementConstant),
        typeof(VirtualNetworkPeeringLevelConstant),
        typeof(VirtualNetworkPeeringStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddressSpaceModel),
        typeof(SubResourceModel),
        typeof(VirtualNetworkBgpCommunitiesModel),
        typeof(VirtualNetworkEncryptionModel),
        typeof(VirtualNetworkPeeringModel),
        typeof(VirtualNetworkPeeringPropertiesFormatModel),
    };
}
