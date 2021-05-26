using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesDisasterRecoveryConfigs
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2017-04-01";
        public string Name => "AuthorizationRulesDisasterRecoveryConfigs";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new DisasterRecoveryConfigsGetAuthorizationRule(),
            new DisasterRecoveryConfigsListAuthorizationRules(),
            new DisasterRecoveryConfigsListKeys(),
        };
    }
}