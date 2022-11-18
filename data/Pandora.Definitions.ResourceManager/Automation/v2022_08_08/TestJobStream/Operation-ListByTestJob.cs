using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.TestJobStream;

internal class ListByTestJobOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new RunbookId();

\t\tpublic override Type NestedItemType() => typeof(JobStreamModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByTestJobOperation.ListByTestJobOptions);

\t\tpublic override string? UriSuffix() => "/draft/testJob/streams";

    internal class ListByTestJobOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
