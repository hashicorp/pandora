using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.VirtualNetworkRules
{
    internal class NamespacesGetVirtualNetworkRuleOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new VirtualnetworkruleId();

        public override Type? ResponseObject() => typeof(VirtualNetworkRuleModel);


    }
}
