using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.PrivateEndpointConnections
{
    internal class CreateOperation : Operations.PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(PrivateEndpointConnectionModel);
        }

        public override ResourceID? ResourceId()
        {
            return new PrivateEndpointConnectionId();
        }

        public override Type? ResponseObject()
        {
            return typeof(PrivateEndpointConnectionModel);
        }


    }
}
