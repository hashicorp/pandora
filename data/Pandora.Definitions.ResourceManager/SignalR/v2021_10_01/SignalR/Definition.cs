using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;

internal class Definition : ResourceDefinition
{
    public string Name => "SignalR";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
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
