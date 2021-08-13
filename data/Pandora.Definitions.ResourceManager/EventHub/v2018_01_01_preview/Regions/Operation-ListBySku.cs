using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Regions
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

        public override Type NestedItemType()
        {
            return typeof(MessagingRegionsModel);
        }

        public override string? UriSuffix()
        {
            return "/regions";
        }


    }
}
