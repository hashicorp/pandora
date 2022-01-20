using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.PowerBIDedicated;

internal class Definition : ResourceDefinition
{
    public string Name => "PowerBIDedicated";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CapacitiesListSkusOperation(),
    };
}
