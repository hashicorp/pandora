using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.PrivateEndpointConnection
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "ee1dc806b00b73458a7d0de7b05da3c56c756cfb" 

        public string ApiVersion => "2021-07-01";
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
