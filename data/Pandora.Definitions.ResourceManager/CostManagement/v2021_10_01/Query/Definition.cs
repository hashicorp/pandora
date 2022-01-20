using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Query;

internal class Definition : ResourceDefinition
{
    public string Name => "Query";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new UsageOperation(),
        new UsageByExternalCloudProviderTypeOperation(),
    };
}
