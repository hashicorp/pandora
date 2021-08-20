using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubs
{
    internal class GetAuthorizationRuleOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new AuthorizationRuleId();

        public override Type? ResponseObject() => typeof(AuthorizationRuleModel);


    }
}
