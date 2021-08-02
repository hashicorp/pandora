using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
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

        public override object? RequestObject()
        {
            return new VirtualNetworkRuleModel();
        }

        public override ResourceID? ResourceId()
        {
            return new VirtualnetworkruleId();
        }

        public override object? ResponseObject()
        {
            return new VirtualNetworkRuleModel();
        }


    }
}
