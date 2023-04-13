using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Functions;

internal class ListByStreamingJobOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new StreamingJobId();

    public override Type NestedItemType() => typeof(FunctionModel);

    public override Type? OptionsObject() => typeof(ListByStreamingJobOperation.ListByStreamingJobOptions);

    public override string? UriSuffix() => "/functions";

    internal class ListByStreamingJobOptions
    {
        [QueryStringName("$select")]
        [Optional]
        public string Select { get; set; }
    }
}
