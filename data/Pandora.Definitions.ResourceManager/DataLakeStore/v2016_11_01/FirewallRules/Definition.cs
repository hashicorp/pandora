using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.FirewallRules;

internal class Definition : ResourceDefinition
{
    public string Name => "FirewallRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAccountOperation(),
        new UpdateOperation(),
    };
}
