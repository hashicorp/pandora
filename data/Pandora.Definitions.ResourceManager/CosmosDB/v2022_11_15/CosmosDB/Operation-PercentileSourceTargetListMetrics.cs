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

internal class PercentileSourceTargetListMetricsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SourceRegionTargetRegionId();

    public override Type? ResponseObject() => typeof(PercentileMetricListResultModel);

    public override Type? OptionsObject() => typeof(PercentileSourceTargetListMetricsOperation.PercentileSourceTargetListMetricsOptions);

    public override string? UriSuffix() => "/percentile/metrics";

    internal class PercentileSourceTargetListMetricsOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
