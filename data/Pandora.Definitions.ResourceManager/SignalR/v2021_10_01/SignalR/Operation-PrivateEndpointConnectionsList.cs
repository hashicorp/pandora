using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;

internal class PrivateEndpointConnectionsListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SignalRId();

    public override Type NestedItemType() => typeof(PrivateEndpointConnectionModel);

    public override string? UriSuffix() => "/privateEndpointConnections";


}
