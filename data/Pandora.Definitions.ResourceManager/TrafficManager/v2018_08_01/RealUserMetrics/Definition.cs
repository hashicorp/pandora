using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.RealUserMetrics;

internal class Definition : ResourceDefinition
{
    public string Name => "RealUserMetrics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TrafficManagerUserMetricsKeysCreateOrUpdateOperation(),
        new TrafficManagerUserMetricsKeysDeleteOperation(),
        new TrafficManagerUserMetricsKeysGetOperation(),
    };
}
