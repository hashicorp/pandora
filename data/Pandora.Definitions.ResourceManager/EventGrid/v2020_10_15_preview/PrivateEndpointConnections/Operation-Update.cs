using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PrivateEndpointConnections
{
    internal class UpdateOperation : Operations.PutOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(PrivateEndpointConnectionModel);

        public override ResourceID? ResourceId() => new PrivateEndpointConnectionId();

        public override Type? ResponseObject() => typeof(PrivateEndpointConnectionModel);


    }
}
