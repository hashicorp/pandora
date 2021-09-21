using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.PrivateEndpointConnection
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "ce90f9b45945c73b8f38649ee6ead390ff6efe7b" 

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
