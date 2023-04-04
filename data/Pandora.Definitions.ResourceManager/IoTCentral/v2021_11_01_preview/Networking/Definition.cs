using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.IoTCentral.v2021_11_01_preview.Networking;

internal class Definition : ResourceDefinition
{
    public string Name => "Networking";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateEndpointConnectionsCreateOperation(),
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateLinksGetOperation(),
        new PrivateLinksListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionListResultModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkResourceModel),
        typeof(PrivateLinkResourceListResultModel),
        typeof(PrivateLinkResourcePropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
    };
}
