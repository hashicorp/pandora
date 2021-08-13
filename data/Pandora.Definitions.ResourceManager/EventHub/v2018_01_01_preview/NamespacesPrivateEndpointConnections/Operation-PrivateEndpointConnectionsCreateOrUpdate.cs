using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NamespacesPrivateEndpointConnections
{
    internal class PrivateEndpointConnectionsCreateOrUpdateOperation : Operations.PutOperation
    {
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
