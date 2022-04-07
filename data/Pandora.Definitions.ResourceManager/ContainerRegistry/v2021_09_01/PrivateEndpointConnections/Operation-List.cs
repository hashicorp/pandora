using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.PrivateEndpointConnections;

internal class ListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new RegistriesId();

    public override Type NestedItemType() => typeof(PrivateEndpointConnectionModel);

    public override string? UriSuffix() => "/privateEndpointConnections";


}
