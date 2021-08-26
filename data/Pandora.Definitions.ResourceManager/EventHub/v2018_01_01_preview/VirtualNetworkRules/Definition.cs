using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.VirtualNetworkRules
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "5844fecb75c31a578ab2548caa8524e6126b0520" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "VirtualNetworkRules";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesCreateOrUpdateVirtualNetworkRuleOperation(),
            new NamespacesDeleteVirtualNetworkRuleOperation(),
            new NamespacesGetVirtualNetworkRuleOperation(),
            new NamespacesListVirtualNetworkRulesOperation(),
        };
    }
}
