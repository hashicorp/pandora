using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NamespacesPrivateEndpointConnections
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "NamespacesPrivateEndpointConnections";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new PrivateEndpointConnectionsCreateOrUpdateOperation(),
            new PrivateEndpointConnectionsDeleteOperation(),
            new PrivateEndpointConnectionsGetOperation(),
            new PrivateEndpointConnectionsListOperation(),
        };
    }
}
