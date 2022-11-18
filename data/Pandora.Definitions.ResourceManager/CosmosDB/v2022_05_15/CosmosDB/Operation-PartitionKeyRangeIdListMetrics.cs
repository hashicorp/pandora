using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDB;

internal class PartitionKeyRangeIdListMetricsOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new PartitionKeyRangeIdId();

\t\tpublic override Type? ResponseObject() => typeof(PartitionMetricListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(PartitionKeyRangeIdListMetricsOperation.PartitionKeyRangeIdListMetricsOptions);

\t\tpublic override string? UriSuffix() => "/metrics";

    internal class PartitionKeyRangeIdListMetricsOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
