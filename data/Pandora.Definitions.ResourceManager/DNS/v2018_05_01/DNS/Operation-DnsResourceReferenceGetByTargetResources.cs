using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.DNS
{
    internal class DnsResourceReferenceGetByTargetResourcesOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(DnsResourceReferenceRequestModel);

        public override ResourceID? ResourceId() => new SubscriptionId();

        public override Type? ResponseObject() => typeof(DnsResourceReferenceResultModel);

        public override string? UriSuffix() => "/providers/Microsoft.Network/getDnsResourceReference";


    }
}
