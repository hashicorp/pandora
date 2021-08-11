using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Regions
{
    internal class ListBySkuOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new SkuId();
        }

        public override object NestedItemType()
        {
            return new MessagingRegionsModel();
        }

        public override string? UriSuffix()
        {
            return "/regions";
        }


    }
}
