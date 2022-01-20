using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts;

internal class Definition : ResourceDefinition
{
    public string Name => "Alerts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DismissOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListExternalOperation(),
    };
}
