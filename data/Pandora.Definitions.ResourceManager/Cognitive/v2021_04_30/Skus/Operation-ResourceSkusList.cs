using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.Skus
{
    internal class ResourceSkusListOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new SubscriptionId();

        public override Type NestedItemType() => typeof(ResourceSkuModel);

        public override string? UriSuffix() => "/providers/Microsoft.CognitiveServices/skus";


    }
}
