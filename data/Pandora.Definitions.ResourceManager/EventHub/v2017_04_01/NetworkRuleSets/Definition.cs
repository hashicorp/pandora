using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.NetworkRuleSets
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1b64fac98b004c439dfffff4cbe93e413ff86709" 

        public string ApiVersion => "2017-04-01";
        public string Name => "NetworkRuleSets";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesCreateOrUpdateNetworkRuleSetOperation(),
            new NamespacesGetNetworkRuleSetOperation(),
        };
    }
}
