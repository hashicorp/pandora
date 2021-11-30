using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerNamespaces
{
    internal class RegenerateKeyOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(PartnerNamespaceRegenerateKeyRequestModel);

        public override ResourceID? ResourceId() => new PartnerNamespaceId();

        public override Type? ResponseObject() => typeof(PartnerNamespaceSharedAccessKeysModel);

        public override string? UriSuffix() => "/regenerateKey";


    }
}
