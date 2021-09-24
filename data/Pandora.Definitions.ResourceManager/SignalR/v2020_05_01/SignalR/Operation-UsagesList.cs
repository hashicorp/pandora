using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    internal class UsagesListOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new LocationId();

        public override Type NestedItemType() => typeof(SignalRUsageModel);

        public override string? UriSuffix() => "/usages";


    }
}
