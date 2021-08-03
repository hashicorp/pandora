using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.EventHubs
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
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
            return new EventhubModel();
        }

        public override ResourceID? ResourceId()
        {
            return new EventhubId();
        }

        public override object? ResponseObject()
        {
            return new EventhubModel();
        }


    }
}
