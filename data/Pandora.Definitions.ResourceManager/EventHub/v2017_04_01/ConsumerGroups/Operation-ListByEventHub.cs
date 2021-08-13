using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.ConsumerGroups
{
    internal class ListByEventHubOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new EventhubId();
        }

        public override Type NestedItemType()
        {
            return typeof(ConsumerGroupModel);
        }

        public override Type? OptionsObject()
        {
            return typeof(ListByEventHubOperation.ListByEventHubOptions);
        }

        public override string? UriSuffix()
        {
            return "/consumergroups";
        }

        internal class ListByEventHubOptions
        {
            [QueryStringName("$skip")]
            [Optional]
            public int Skip { get; set; }
            [QueryStringName("$top")]
            [Optional]
            public int Top { get; set; }
        }
    }
}
