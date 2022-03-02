using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview.ConfidentialLedger;

internal class Definition : ResourceDefinition
{
    public string Name => "ConfidentialLedger";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new LedgerCreateOperation(),
        new LedgerDeleteOperation(),
        new LedgerGetOperation(),
        new LedgerListByResourceGroupOperation(),
        new LedgerListBySubscriptionOperation(),
        new LedgerUpdateOperation(),
    };
}
