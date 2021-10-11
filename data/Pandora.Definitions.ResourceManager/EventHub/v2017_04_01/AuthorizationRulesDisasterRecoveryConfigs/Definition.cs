using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesDisasterRecoveryConfigs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "865f0857a8785640f9bca0ab9842d29be589f2a8" 

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
