using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account
{
    internal class ListBySubscriptionOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new ProviderId();

        public override Type NestedItemType() => typeof(AccountModel);

        public override string? UriSuffix() => "/accounts";


    }
}
