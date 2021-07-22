using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesDisasterRecoveryConfigs
{
    internal class DisasterRecoveryConfigsGetAuthorizationRule : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new AuthorizationRuleId();
        }

        public override object? ResponseObject()
        {
            return new AuthorizationRule();
        }
    }
}
