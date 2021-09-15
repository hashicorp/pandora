using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.PrivateEndpointConnections
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "ee1dc806b00b73458a7d0de7b05da3c56c756cfb" 

        public string ApiVersion => "2020-10-01";
        public string Name => "PrivateEndpointConnections";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
        };
    }
}
