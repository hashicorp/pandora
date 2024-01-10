using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

internal class AlertsGetSummaryOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(AlertsSummaryModel);

    public override Type? OptionsObject() => typeof(AlertsGetSummaryOperation.AlertsGetSummaryOptions);

    public override string? UriSuffix() => "/providers/Microsoft.AlertsManagement/alertsSummary";

    internal class AlertsGetSummaryOptions
    {
        [QueryStringName("alertRule")]
        [Optional]
        public string AlertRule { get; set; }

        [QueryStringName("alertState")]
        [Optional]
        public AlertStateConstant AlertState { get; set; }

        [QueryStringName("customTimeRange")]
        [Optional]
        public string CustomTimeRange { get; set; }

        [QueryStringName("groupby")]
        public AlertsSummaryGroupByFieldsConstant Groupby { get; set; }

        [QueryStringName("includeSmartGroupsCount")]
        [Optional]
        public bool IncludeSmartGroupsCount { get; set; }

        [QueryStringName("monitorCondition")]
        [Optional]
        public MonitorConditionConstant MonitorCondition { get; set; }

        [QueryStringName("monitorService")]
        [Optional]
        public MonitorServiceConstant MonitorService { get; set; }

        [QueryStringName("severity")]
        [Optional]
        public SeverityConstant Severity { get; set; }

        [QueryStringName("targetResource")]
        [Optional]
        public string TargetResource { get; set; }

        [QueryStringName("targetResourceGroup")]
        [Optional]
        public string TargetResourceGroup { get; set; }

        [QueryStringName("targetResourceType")]
        [Optional]
        public string TargetResourceType { get; set; }

        [QueryStringName("timeRange")]
        [Optional]
        public TimeRangeConstant TimeRange { get; set; }
    }
}
