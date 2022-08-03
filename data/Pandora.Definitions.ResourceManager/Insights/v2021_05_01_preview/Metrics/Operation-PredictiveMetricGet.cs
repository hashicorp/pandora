using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.Metrics;

internal class PredictiveMetricGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new AutoscalesettingId();

    public override Type? ResponseObject() => typeof(PredictiveResponseModel);

    public override Type? OptionsObject() => typeof(PredictiveMetricGetOperation.PredictiveMetricGetOptions);

    public override string? UriSuffix() => "/predictiveMetrics";

    internal class PredictiveMetricGetOptions
    {
        [QueryStringName("aggregation")]
        public string Aggregation { get; set; }

        [QueryStringName("interval")]
        public string Interval { get; set; }

        [QueryStringName("metricName")]
        public string MetricName { get; set; }

        [QueryStringName("metricNamespace")]
        public string MetricNamespace { get; set; }

        [QueryStringName("timespan")]
        public string Timespan { get; set; }
    }
}
