using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Operation;

internal class Definition : ResourceDefinition
{
    public string Name => "Operation";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RegistriesCheckNameAvailabilityOperation(),
    };
}
