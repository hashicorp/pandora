using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e68d33c8165c51219c4643eead40efd6a9ab7bd2" 

        public string ApiVersion => "2020-05-01";
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
            new PrivateEndpointConnectionsDeleteOperation(),
            new PrivateEndpointConnectionsGetOperation(),
            new PrivateEndpointConnectionsUpdateOperation(),
            new PrivateLinkResourcesListOperation(),
            new RegenerateKeyOperation(),
            new RestartOperation(),
            new UpdateOperation(),
            new UsagesListOperation(),
        };
    }
}
