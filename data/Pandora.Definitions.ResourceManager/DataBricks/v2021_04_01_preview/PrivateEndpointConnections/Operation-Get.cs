using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.PrivateEndpointConnections;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new PrivateEndpointConnectionId();

    public override Type? ResponseObject() => typeof(PrivateEndpointConnectionModel);


}
