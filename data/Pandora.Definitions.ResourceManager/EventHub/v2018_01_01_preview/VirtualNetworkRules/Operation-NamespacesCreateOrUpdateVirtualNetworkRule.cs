using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.VirtualNetworkRules
{
    internal class NamespacesCreateOrUpdateVirtualNetworkRule : PutOperation
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
            return new VirtualNetworkRule();
        }

        public override ResourceID? ResourceId()
        {
            return new VirtualnetworkruleId();
        }

        public override object? ResponseObject()
        {
            return new VirtualNetworkRule();
        }
    }
}
