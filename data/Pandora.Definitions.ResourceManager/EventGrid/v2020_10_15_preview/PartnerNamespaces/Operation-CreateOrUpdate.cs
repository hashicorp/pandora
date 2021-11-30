using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerNamespaces
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Created,
        };

        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(PartnerNamespaceModel);

        public override ResourceID? ResourceId() => new PartnerNamespaceId();

        public override Type? ResponseObject() => typeof(PartnerNamespaceModel);


    }
}
