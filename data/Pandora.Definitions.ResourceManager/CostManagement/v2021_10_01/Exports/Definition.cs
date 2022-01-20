using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Exports;

internal class Definition : ResourceDefinition
{
    public string Name => "Exports";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ExecuteOperation(),
        new GetOperation(),
        new GetExecutionHistoryOperation(),
        new ListOperation(),
    };
}
