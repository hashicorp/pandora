using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.PrivateEndpointConnections
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(PrivateEndpointConnectionModel);

        public override ResourceID? ResourceId() => new PrivateEndpointConnectionId();

        public override Type? ResponseObject() => typeof(PrivateEndpointConnectionModel);


    }
}
