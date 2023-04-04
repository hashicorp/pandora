using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.PrivateEndpointConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateEndpointConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByFactoryOperation(),
        new PrivateEndpointConnectionCreateOrUpdateOperation(),
        new PrivateEndpointConnectionDeleteOperation(),
        new PrivateEndpointConnectionGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ArmIdWrapperModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionResourceModel),
        typeof(PrivateLinkConnectionApprovalRequestModel),
        typeof(PrivateLinkConnectionApprovalRequestResourceModel),
        typeof(PrivateLinkConnectionStateModel),
        typeof(RemotePrivateEndpointConnectionModel),
    };
}
