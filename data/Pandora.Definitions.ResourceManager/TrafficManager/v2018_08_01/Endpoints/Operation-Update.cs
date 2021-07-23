using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Endpoints
{
    internal class Update : PatchOperation
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
            return new Endpoint();
        }

        public override ResourceID? ResourceId()
        {
            return new TrafficmanagerprofileId();
        }

        public override object? ResponseObject()
        {
            return new Endpoint();
        }


    }
}
