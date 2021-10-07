using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.PrivateEndpointConnection
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1ec9a8fe851a92ff4c241110cef58238ced59c6c" 

        public string ApiVersion => "2020-12-01-preview";
        public string Name => "PrivateEndpointConnection";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByAccountOperation(),
        };
    }
}
