using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.GeographicHierarchies;

internal class Definition : ResourceDefinition
{
    public string Name => "GeographicHierarchies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetDefaultOperation(),
    };
}
