using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces
{
    internal class Delete : DeleteOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
                HttpStatusCode.Accepted,
                HttpStatusCode.NoContent,
            };
        }

        public override bool LongRunning()
        {
            return true;
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }
    }
}
