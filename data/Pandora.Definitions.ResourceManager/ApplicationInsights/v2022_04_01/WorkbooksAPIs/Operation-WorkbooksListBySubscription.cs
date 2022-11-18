using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.WorkbooksAPIs;

internal class WorkbooksListBySubscriptionOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new SubscriptionId();

\t\tpublic override Type NestedItemType() => typeof(WorkbookModel);

\t\tpublic override Type? OptionsObject() => typeof(WorkbooksListBySubscriptionOperation.WorkbooksListBySubscriptionOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Insights/workbooks";

    internal class WorkbooksListBySubscriptionOptions
    {
        [QueryStringName("canFetchContent")]
        [Optional]
        public bool CanFetchContent { get; set; }

        [QueryStringName("category")]
        public CategoryTypeConstant Category { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public Csv<string> Tags { get; set; }
    }
}
