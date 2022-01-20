using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NetworkRuleSets;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkRuleSets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NamespacesCreateOrUpdateNetworkRuleSetOperation(),
        new NamespacesGetNetworkRuleSetOperation(),
    };
}
