using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NamespacesPrivateEndpointConnections
{
    internal class PrivateEndpointConnectionsGetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new PrivateEndpointConnectionId();

        public override Type? ResponseObject() => typeof(PrivateEndpointConnectionModel);


    }
}
