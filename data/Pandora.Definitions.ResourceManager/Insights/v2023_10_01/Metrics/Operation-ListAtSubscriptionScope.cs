using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.Metrics;

internal class ListAtSubscriptionScopeOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(ResponseModel);

    public override Type? OptionsObject() => typeof(ListAtSubscriptionScopeOperation.ListAtSubscriptionScopeOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Insights/metrics";

    internal class ListAtSubscriptionScopeOptions
    {
        [QueryStringName("aggregation")]
        [Optional]
        public string Aggregation { get; set; }

        [QueryStringName("AutoAdjustTimegrain")]
        [Optional]
        public bool AutoAdjustTimegrain { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("interval")]
        [Optional]
        public string Interval { get; set; }

        [QueryStringName("metricnames")]
        [Optional]
        public string Metricnames { get; set; }

        [QueryStringName("metricnamespace")]
        [Optional]
        public string Metricnamespace { get; set; }

        [QueryStringName("orderby")]
        [Optional]
        public string Orderby { get; set; }

        [QueryStringName("region")]
        public string Region { get; set; }

        [QueryStringName("resultType")]
        [Optional]
        public MetricResultTypeConstant ResultType { get; set; }

        [QueryStringName("rollupby")]
        [Optional]
        public string Rollupby { get; set; }

        [QueryStringName("timespan")]
        [Optional]
        public string Timespan { get; set; }

        [QueryStringName("top")]
        [Optional]
        public int Top { get; set; }

        [QueryStringName("ValidateDimensions")]
        [Optional]
        public bool ValidateDimensions { get; set; }
    }
}
