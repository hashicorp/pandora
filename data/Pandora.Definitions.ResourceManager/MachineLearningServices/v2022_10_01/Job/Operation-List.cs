using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;

internal class ListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type NestedItemType() => typeof(JobBaseResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(ListOperation.ListOptions);

\t\tpublic override string? UriSuffix() => "/jobs";

    internal class ListOptions
    {
        [QueryStringName("jobType")]
        [Optional]
        public string JobType { get; set; }

        [QueryStringName("listViewType")]
        [Optional]
        public ListViewTypeConstant ListViewType { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("tag")]
        [Optional]
        public string Tag { get; set; }
    }
}
