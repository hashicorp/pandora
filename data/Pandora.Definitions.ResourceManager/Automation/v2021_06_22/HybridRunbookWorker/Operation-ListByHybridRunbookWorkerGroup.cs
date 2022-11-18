using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.HybridRunbookWorker;

internal class ListByHybridRunbookWorkerGroupOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new HybridRunbookWorkerGroupId();

\t\tpublic override Type NestedItemType() => typeof(HybridRunbookWorkerModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByHybridRunbookWorkerGroupOperation.ListByHybridRunbookWorkerGroupOptions);

\t\tpublic override string? UriSuffix() => "/hybridRunbookWorkers";

    internal class ListByHybridRunbookWorkerGroupOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
