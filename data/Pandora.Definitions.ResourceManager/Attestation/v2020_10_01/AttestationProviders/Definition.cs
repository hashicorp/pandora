using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders;

internal class Definition : ResourceDefinition
{
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
