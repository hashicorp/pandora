using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.VNetPeering
{
    internal class ListByWorkspaceOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new WorkspaceId();

        public override Type NestedItemType() => typeof(VirtualNetworkPeeringModel);

        public override string? UriSuffix() => "/virtualNetworkPeerings";


    }
}
