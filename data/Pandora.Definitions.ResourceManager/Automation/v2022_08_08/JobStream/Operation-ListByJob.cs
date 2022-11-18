using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.JobStream;

internal class ListByJobOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new JobId();

\t\tpublic override Type NestedItemType() => typeof(JobStreamModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByJobOperation.ListByJobOptions);

\t\tpublic override string? UriSuffix() => "/streams";

    internal class ListByJobOptions
    {
        [HeaderName("clientRequestId")]
        [Optional]
        public string ClientRequestId { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
