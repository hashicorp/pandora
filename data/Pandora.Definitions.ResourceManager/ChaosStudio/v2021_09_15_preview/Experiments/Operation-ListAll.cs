using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments;

internal class ListAllOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(ExperimentModel);

    public override Type? OptionsObject() => typeof(ListAllOperation.ListAllOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Chaos/experiments";

    internal class ListAllOptions
    {
        [QueryStringName("continuationToken")]
        [Optional]
        public string ContinuationToken { get; set; }

        [QueryStringName("running")]
        [Optional]
        public bool Running { get; set; }
    }
}
