using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.PrivateEndpointConnections
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b9aa58703085cdccefe4b8726b0757c00adc9072" 

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
