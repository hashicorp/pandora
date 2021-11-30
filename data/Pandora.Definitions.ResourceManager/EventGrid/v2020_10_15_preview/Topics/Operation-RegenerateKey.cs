using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{
    internal class RegenerateKeyOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(TopicRegenerateKeyRequestModel);

        public override ResourceID? ResourceId() => new TopicId();

        public override Type? ResponseObject() => typeof(TopicSharedAccessKeysModel);

        public override string? UriSuffix() => "/regenerateKey";


    }
}
