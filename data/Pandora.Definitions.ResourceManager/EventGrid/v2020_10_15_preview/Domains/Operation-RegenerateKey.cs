using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Domains
{
    internal class RegenerateKeyOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => typeof(DomainRegenerateKeyRequestModel);

        public override ResourceID? ResourceId() => new DomainId();

        public override Type? ResponseObject() => typeof(DomainSharedAccessKeysModel);

        public override string? UriSuffix() => "/regenerateKey";


    }
}
