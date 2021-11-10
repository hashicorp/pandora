using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.FirewallRules
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new FirewallRuleId();

        public override Type? ResponseObject() => typeof(FirewallRuleModel);


    }
}
