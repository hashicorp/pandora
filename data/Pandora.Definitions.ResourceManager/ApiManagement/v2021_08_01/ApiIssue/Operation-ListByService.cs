using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiIssue;

internal class ListByServiceOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ApiId();

\t\tpublic override Type NestedItemType() => typeof(IssueContractModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByServiceOperation.ListByServiceOptions);

\t\tpublic override string? UriSuffix() => "/issues";

    internal class ListByServiceOptions
    {
        [QueryStringName("expandCommentsAttachments")]
        [Optional]
        public bool ExpandCommentsAttachments { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
