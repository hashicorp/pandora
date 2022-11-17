using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.HybridRunbookWorker;

internal class ListByHybridRunbookWorkerGroupOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new HybridRunbookWorkerGroupId();

    public override Type NestedItemType() => typeof(HybridRunbookWorkerModel);

    public override Type? OptionsObject() => typeof(ListByHybridRunbookWorkerGroupOperation.ListByHybridRunbookWorkerGroupOptions);

    public override string? UriSuffix() => "/hybridRunbookWorkers";

    internal class ListByHybridRunbookWorkerGroupOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
