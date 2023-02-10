using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.CosmosDB;

internal class PartitionKeyRangeIdListMetricsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new PartitionKeyRangeIdId();

    public override Type? ResponseObject() => typeof(PartitionMetricListResultModel);

    public override Type? OptionsObject() => typeof(PartitionKeyRangeIdListMetricsOperation.PartitionKeyRangeIdListMetricsOptions);

    public override string? UriSuffix() => "/metrics";

    internal class PartitionKeyRangeIdListMetricsOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
