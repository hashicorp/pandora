using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{
    internal class ListGlobalBySubscriptionForTopicTypeOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new ProviderTopicTypeId();

        public override Type NestedItemType() => typeof(EventSubscriptionModel);

        public override Type? OptionsObject() => typeof(ListGlobalBySubscriptionForTopicTypeOperation.ListGlobalBySubscriptionForTopicTypeOptions);

        public override string? UriSuffix() => "/eventSubscriptions";

        internal class ListGlobalBySubscriptionForTopicTypeOptions
        {
            [QueryStringName("$filter")]
            [Optional]
            public string Filter { get; set; }

            [QueryStringName("$top")]
            [Optional]
            public int Top { get; set; }
        }
    }
}
