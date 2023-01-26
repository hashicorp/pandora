using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PrivateLinkServices;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateLinkServices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckPrivateLinkServiceVisibilityOperation(),
        new CheckPrivateLinkServiceVisibilityByResourceGroupOperation(),
        new DeleteOperation(),
        new DeletePrivateEndpointConnectionOperation(),
        new GetOperation(),
        new GetPrivateEndpointConnectionOperation(),
        new ListOperation(),
        new ListAutoApprovedPrivateLinkServicesOperation(),
        new ListAutoApprovedPrivateLinkServicesByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListPrivateEndpointConnectionsOperation(),
        new UpdatePrivateEndpointConnectionOperation(),
    };
}
