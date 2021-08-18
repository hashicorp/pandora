using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.PrivateEndpointConnection
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "60d6c393c7e71b45ebe0976a35fd7a5841993159" 

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
