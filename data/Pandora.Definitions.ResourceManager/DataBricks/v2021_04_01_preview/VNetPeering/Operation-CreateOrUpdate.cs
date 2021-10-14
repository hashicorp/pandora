using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.VNetPeering
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(VirtualNetworkPeeringModel);

        public override ResourceID? ResourceId() => new VirtualNetworkPeeringId();

        public override Type? ResponseObject() => typeof(VirtualNetworkPeeringModel);


    }
}
