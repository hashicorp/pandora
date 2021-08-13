using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    internal class PrivateEndpointConnectionsUpdateOperation : Operations.PutOperation
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
