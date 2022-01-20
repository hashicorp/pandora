using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Targets;

internal class ListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ProviderId();

    public override Type NestedItemType() => typeof(TargetModel);

    public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Chaos/targets";

    internal class ListOptions
    {
        [QueryStringName("continuationToken")]
        [Optional]
        public string ContinuationToken { get; set; }
    }
}
