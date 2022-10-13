using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.WebPubSub.v2021_10_01.WebPubSub;

internal class Definition : ResourceDefinition
{
    public string Name => "WebPubSub";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new HubsCreateOrUpdateOperation(),
        new HubsDeleteOperation(),
        new HubsGetOperation(),
        new HubsListOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new ListSkusOperation(),
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateEndpointConnectionsUpdateOperation(),
        new PrivateLinkResourcesListOperation(),
        new RegenerateKeyOperation(),
        new RestartOperation(),
        new SharedPrivateLinkResourcesCreateOrUpdateOperation(),
        new SharedPrivateLinkResourcesDeleteOperation(),
        new SharedPrivateLinkResourcesGetOperation(),
        new SharedPrivateLinkResourcesListOperation(),
        new UpdateOperation(),
        new UsagesListOperation(),
    };
}
