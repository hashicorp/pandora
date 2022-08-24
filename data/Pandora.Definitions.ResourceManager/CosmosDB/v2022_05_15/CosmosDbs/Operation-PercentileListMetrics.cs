using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDbs;

internal class PercentileListMetricsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new DatabaseAccountId();

    public override Type? ResponseObject() => typeof(PercentileMetricListResultModel);

    public override Type? OptionsObject() => typeof(PercentileListMetricsOperation.PercentileListMetricsOptions);

    public override string? UriSuffix() => "/percentile/metrics";

    internal class PercentileListMetricsOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
