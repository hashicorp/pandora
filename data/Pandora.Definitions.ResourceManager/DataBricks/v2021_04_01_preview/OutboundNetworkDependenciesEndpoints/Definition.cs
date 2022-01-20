using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.OutboundNetworkDependenciesEndpoints;

internal class Definition : ResourceDefinition
{
    public string Name => "OutboundNetworkDependenciesEndpoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
}
