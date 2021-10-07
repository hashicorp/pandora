using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1ec9a8fe851a92ff4c241110cef58238ced59c6c" 

        public string ApiVersion => "2021-01-01-preview";
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
