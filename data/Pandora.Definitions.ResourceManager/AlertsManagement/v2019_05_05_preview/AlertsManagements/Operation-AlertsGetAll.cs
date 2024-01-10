using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

internal class AlertsGetAllOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(AlertModel);

    public override Type? OptionsObject() => typeof(AlertsGetAllOperation.AlertsGetAllOptions);

    public override string? UriSuffix() => "/providers/Microsoft.AlertsManagement/alerts";

    internal class AlertsGetAllOptions
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

        [QueryStringName("includeContext")]
        [Optional]
        public bool IncludeContext { get; set; }

        [QueryStringName("includeEgressConfig")]
        [Optional]
        public bool IncludeEgressConfig { get; set; }

        [QueryStringName("monitorCondition")]
        [Optional]
        public MonitorConditionConstant MonitorCondition { get; set; }

        [QueryStringName("monitorService")]
        [Optional]
        public MonitorServiceConstant MonitorService { get; set; }

        [QueryStringName("pageCount")]
        [Optional]
        public int PageCount { get; set; }

        [QueryStringName("select")]
        [Optional]
        public string Select { get; set; }

        [QueryStringName("severity")]
        [Optional]
        public SeverityConstant Severity { get; set; }

        [QueryStringName("smartGroupId")]
        [Optional]
        public string SmartGroupId { get; set; }

        [QueryStringName("sortBy")]
        [Optional]
        public AlertsSortByFieldsConstant SortBy { get; set; }

        [QueryStringName("sortOrder")]
        [Optional]
        public SortOrderConstant SortOrder { get; set; }

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
