using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.SmartGroups;

internal class GetAllOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(SmartGroupModel);

    public override Type? OptionsObject() => typeof(GetAllOperation.GetAllOptions);

    public override string? UriSuffix() => "/providers/Microsoft.AlertsManagement/smartGroups";

    internal class GetAllOptions
    {
        [QueryStringName("monitorCondition")]
        [Optional]
        public MonitorConditionConstant MonitorCondition { get; set; }

        [QueryStringName("monitorService")]
        [Optional]
        public MonitorServiceConstant MonitorService { get; set; }

        [QueryStringName("pageCount")]
        [Optional]
        public int PageCount { get; set; }

        [QueryStringName("severity")]
        [Optional]
        public SeverityConstant Severity { get; set; }

        [QueryStringName("smartGroupState")]
        [Optional]
        public AlertStateConstant SmartGroupState { get; set; }

        [QueryStringName("sortBy")]
        [Optional]
        public SmartGroupsSortByFieldsConstant SortBy { get; set; }

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
