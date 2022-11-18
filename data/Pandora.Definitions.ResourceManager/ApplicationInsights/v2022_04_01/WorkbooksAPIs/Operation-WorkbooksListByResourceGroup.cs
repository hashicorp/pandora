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

internal class WorkbooksListByResourceGroupOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type NestedItemType() => typeof(WorkbookModel);

\t\tpublic override Type? OptionsObject() => typeof(WorkbooksListByResourceGroupOperation.WorkbooksListByResourceGroupOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Insights/workbooks";

    internal class WorkbooksListByResourceGroupOptions
    {
        [QueryStringName("canFetchContent")]
        [Optional]
        public bool CanFetchContent { get; set; }

        [QueryStringName("category")]
        public CategoryTypeConstant Category { get; set; }

        [QueryStringName("sourceId")]
        [Optional]
        public string SourceId { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public Csv<string> Tags { get; set; }
    }
}
