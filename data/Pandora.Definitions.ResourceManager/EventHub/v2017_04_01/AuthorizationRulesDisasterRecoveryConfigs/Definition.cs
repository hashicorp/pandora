using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesDisasterRecoveryConfigs
{
    internal class Definition : ApiDefinition
    {
        public string Name => "AuthorizationRulesDisasterRecoveryConfigs";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new DisasterRecoveryConfigsGetAuthorizationRuleOperation(),
            new DisasterRecoveryConfigsListAuthorizationRulesOperation(),
            new DisasterRecoveryConfigsListKeysOperation(),
        };
    }
}
