using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.MHSMListPrivateEndpointConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "MHSMListPrivateEndpointConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MHSMPrivateEndpointConnectionsListByResourceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessPolicyUpdateKindConstant),
        typeof(ActionsRequiredConstant),
        typeof(ManagedHsmSkuFamilyConstant),
        typeof(ManagedHsmSkuNameConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MHSMPrivateEndpointModel),
        typeof(MHSMPrivateEndpointConnectionModel),
        typeof(MHSMPrivateEndpointConnectionPropertiesModel),
        typeof(MHSMPrivateLinkServiceConnectionStateModel),
        typeof(ManagedHsmSkuModel),
    };
}
