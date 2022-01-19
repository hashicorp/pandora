using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NetworkRuleSets
{
    internal class Definition : ApiDefinition
    {
        public string Name => "NetworkRuleSets";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesCreateOrUpdateNetworkRuleSetOperation(),
            new NamespacesGetNetworkRuleSetOperation(),
        };
    }
}
