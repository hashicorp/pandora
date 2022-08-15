using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Accounts;

internal class Definition : ResourceDefinition
{
    public string Name => "Accounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new LocationsCheckNameAvailabilityOperation(),
        new MediaservicesCreateOrUpdateOperation(),
        new MediaservicesDeleteOperation(),
        new MediaservicesGetOperation(),
        new MediaservicesGetBySubscriptionOperation(),
        new MediaservicesListOperation(),
        new MediaservicesListBySubscriptionOperation(),
        new MediaservicesListEdgePoliciesOperation(),
        new MediaservicesSyncStorageKeysOperation(),
        new MediaservicesUpdateOperation(),
        new PrivateEndpointConnectionsCreateOrUpdateOperation(),
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateLinkResourcesGetOperation(),
        new PrivateLinkResourcesListOperation(),
    };
}
