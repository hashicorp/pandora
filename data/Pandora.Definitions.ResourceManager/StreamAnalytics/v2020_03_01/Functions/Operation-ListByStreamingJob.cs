using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Functions;

internal class ListByStreamingJobOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new StreamingJobId();

\t\tpublic override Type NestedItemType() => typeof(FunctionModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByStreamingJobOperation.ListByStreamingJobOptions);

\t\tpublic override string? UriSuffix() => "/functions";

    internal class ListByStreamingJobOptions
    {
        [QueryStringName("$select")]
        [Optional]
        public string Select { get; set; }
    }
}
