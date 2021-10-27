using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors
{
    internal class FrontendEndpointsListByFrontDoorOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new FrontDoorId();

        public override Type NestedItemType() => typeof(FrontendEndpointModel);

        public override string? UriSuffix() => "/frontendEndpoints";


    }
}
