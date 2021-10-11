using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.IpFilterRules
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "865f0857a8785640f9bca0ab9842d29be589f2a8" 

        public string ApiVersion => "2018-01-01-preview";
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
