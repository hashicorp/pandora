using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections
{
    internal class Definition : ApiDefinition
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
