using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.AuthorizationRulesDisasterRecoveryConfigs;

internal class Definition : ResourceDefinition
{
    public string Name => "AuthorizationRulesDisasterRecoveryConfigs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DisasterRecoveryConfigsGetAuthorizationRuleOperation(),
        new DisasterRecoveryConfigsListAuthorizationRulesOperation(),
        new DisasterRecoveryConfigsListKeysOperation(),
    };
}
