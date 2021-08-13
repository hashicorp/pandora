using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1e9e2b41c471029b643e58f65caccdd0492a1576" 

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
