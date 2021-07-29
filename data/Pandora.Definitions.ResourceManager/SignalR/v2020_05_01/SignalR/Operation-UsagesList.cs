using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    internal class UsagesListOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new LocationId();
        }

        public override object NestedItemType()
        {
            return new SignalRUsage();
        }

        public override string? UriSuffix()
        {
            return "/usages";
        }


    }
}
