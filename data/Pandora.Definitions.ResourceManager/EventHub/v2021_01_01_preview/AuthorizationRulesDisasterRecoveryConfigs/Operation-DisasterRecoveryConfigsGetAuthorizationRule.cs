using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesDisasterRecoveryConfigs
{
    internal class DisasterRecoveryConfigsGetAuthorizationRuleOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new DisasterRecoveryConfigAuthorizationRuleId();

        public override Type? ResponseObject() => typeof(AuthorizationRuleModel);


    }
}
