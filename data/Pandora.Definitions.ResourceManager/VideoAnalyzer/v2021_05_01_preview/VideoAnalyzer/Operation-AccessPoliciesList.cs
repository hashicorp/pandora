using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;

internal class AccessPoliciesListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "@nextLink";

    public override ResourceID? ResourceId() => new VideoAnalyzerId();

    public override Type NestedItemType() => typeof(AccessPolicyEntityModel);

    public override Type? OptionsObject() => typeof(AccessPoliciesListOperation.AccessPoliciesListOptions);

    public override string? UriSuffix() => "/accessPolicies";

    internal class AccessPoliciesListOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
