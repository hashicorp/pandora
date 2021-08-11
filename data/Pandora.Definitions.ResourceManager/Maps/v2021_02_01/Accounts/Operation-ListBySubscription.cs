using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
    internal class ListBySubscriptionOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override object NestedItemType()
        {
            return new MapsAccountModel();
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.Maps/accounts";
        }


    }
}
