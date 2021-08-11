using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.ConsumerGroups
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

        public override object NestedItemType()
        {
            return new ConsumerGroupModel();
        }

        public override object? OptionsObject()
        {
            return new ListByEventHubOperation.ListByEventHubOptions();
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
