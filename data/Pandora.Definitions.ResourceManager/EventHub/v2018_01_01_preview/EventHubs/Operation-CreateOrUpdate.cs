using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubs
{
    internal class CreateOrUpdate : PutOperation
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
            return new Eventhub();
        }

        public override ResourceID? ResourceId()
        {
            return new EventhubId();
        }

        public override object? ResponseObject()
        {
            return new Eventhub();
        }
    }
}
