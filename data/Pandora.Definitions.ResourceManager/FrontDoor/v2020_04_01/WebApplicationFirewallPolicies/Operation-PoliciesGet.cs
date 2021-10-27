using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies
{
    internal class PoliciesGetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new FrontDoorWebApplicationFirewallPoliciesId();

        public override Type? ResponseObject() => typeof(WebApplicationFirewallPolicyModel);


    }
}
