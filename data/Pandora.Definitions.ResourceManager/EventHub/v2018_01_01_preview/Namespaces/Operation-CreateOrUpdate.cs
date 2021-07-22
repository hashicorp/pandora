using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces
{
    internal class CreateOrUpdate : PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
                HttpStatusCode.Created,
            };
        }

        public override bool LongRunning()
        {
            return true;
        }

        public override object? RequestObject()
        {
            return new EHNamespace();
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override object? ResponseObject()
        {
            return new EHNamespace();
        }
    }
}
