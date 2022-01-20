using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Forecast;

internal class Definition : ResourceDefinition
{
    public string Name => "Forecast";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExternalCloudProviderUsageOperation(),
        new UsageOperation(),
    };
}
