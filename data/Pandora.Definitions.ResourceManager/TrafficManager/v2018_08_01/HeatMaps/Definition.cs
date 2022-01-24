using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.HeatMaps;

internal class Definition : ResourceDefinition
{
    public string Name => "HeatMaps";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new HeatMapGetOperation(),
    };
}
