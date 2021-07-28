using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces
{
    internal class DeleteOperation : Operations.DeleteOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
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
