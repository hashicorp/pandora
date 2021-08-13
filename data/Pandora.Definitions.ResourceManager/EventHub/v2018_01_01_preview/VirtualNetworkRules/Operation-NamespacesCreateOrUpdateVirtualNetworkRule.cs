using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.VirtualNetworkRules
{
    internal class NamespacesCreateOrUpdateVirtualNetworkRuleOperation : Operations.PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(VirtualNetworkRuleModel);
        }

        public override ResourceID? ResourceId()
        {
            return new VirtualnetworkruleId();
        }

        public override Type? ResponseObject()
        {
            return typeof(VirtualNetworkRuleModel);
        }


    }
}
