using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.Videos;

internal class AccessPoliciesListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "@nextLink";

\t\tpublic override ResourceID? ResourceId() => new VideoAnalyzerId();

\t\tpublic override Type NestedItemType() => typeof(AccessPolicyEntityModel);

\t\tpublic override Type? OptionsObject() => typeof(AccessPoliciesListOperation.AccessPoliciesListOptions);

\t\tpublic override string? UriSuffix() => "/accessPolicies";

    internal class AccessPoliciesListOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
