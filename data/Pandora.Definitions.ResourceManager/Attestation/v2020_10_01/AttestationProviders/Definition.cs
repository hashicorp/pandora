using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b28a542b3eb4f2f4f384b14b635d0a835df818cd" 

        public string ApiVersion => "2020-10-01";
        public string Name => "AttestationProviders";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new GetDefaultByLocationOperation(),
            new ListOperation(),
            new ListByResourceGroupOperation(),
            new ListDefaultOperation(),
            new UpdateOperation(),
        };
    }
}
