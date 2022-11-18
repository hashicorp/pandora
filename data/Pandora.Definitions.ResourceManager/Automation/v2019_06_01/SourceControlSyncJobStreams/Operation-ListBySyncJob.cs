using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SourceControlSyncJobStreams;

internal class ListBySyncJobOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new SourceControlSyncJobId();

\t\tpublic override Type NestedItemType() => typeof(SourceControlSyncJobStreamModel);

\t\tpublic override Type? OptionsObject() => typeof(ListBySyncJobOperation.ListBySyncJobOptions);

\t\tpublic override string? UriSuffix() => "/streams";

    internal class ListBySyncJobOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
