using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.StreamingPoliciesAndStreamingLocators;

internal class StreamingPoliciesListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "@odata.nextLink";

\t\tpublic override ResourceID? ResourceId() => new MediaServiceId();

\t\tpublic override Type NestedItemType() => typeof(StreamingPolicyModel);

\t\tpublic override Type? OptionsObject() => typeof(StreamingPoliciesListOperation.StreamingPoliciesListOptions);

\t\tpublic override string? UriSuffix() => "/streamingPolicies";

    internal class StreamingPoliciesListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
