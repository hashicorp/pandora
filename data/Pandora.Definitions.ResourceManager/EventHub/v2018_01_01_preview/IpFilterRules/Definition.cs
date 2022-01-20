using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.IpFilterRules
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "IpFilterRules";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesCreateOrUpdateIpFilterRuleOperation(),
            new NamespacesDeleteIpFilterRuleOperation(),
            new NamespacesGetIpFilterRuleOperation(),
            new NamespacesListIPFilterRulesOperation(),
        };
    }
}
