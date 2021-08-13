using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesDisasterRecoveryConfigs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1e9e2b41c471029b643e58f65caccdd0492a1576" 

        public string ApiVersion => "2017-04-01";
        public string Name => "AuthorizationRulesDisasterRecoveryConfigs";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new DisasterRecoveryConfigsGetAuthorizationRuleOperation(),
            new DisasterRecoveryConfigsListAuthorizationRulesOperation(),
            new DisasterRecoveryConfigsListKeysOperation(),
        };
    }
}
