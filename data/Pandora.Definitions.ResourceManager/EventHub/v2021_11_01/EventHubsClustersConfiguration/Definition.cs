using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubsClustersConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "EventHubsClustersConfiguration";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConfigurationGetOperation(),
        new ConfigurationPatchOperation(),
    };
}
