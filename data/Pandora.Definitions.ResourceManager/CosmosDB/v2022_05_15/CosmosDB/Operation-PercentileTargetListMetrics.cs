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

internal class PercentileTargetListMetricsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new TargetRegionId();

    public override Type? ResponseObject() => typeof(PercentileMetricListResultModel);

    public override Type? OptionsObject() => typeof(PercentileTargetListMetricsOperation.PercentileTargetListMetricsOptions);

    public override string? UriSuffix() => "/percentile/metrics";

    internal class PercentileTargetListMetricsOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
