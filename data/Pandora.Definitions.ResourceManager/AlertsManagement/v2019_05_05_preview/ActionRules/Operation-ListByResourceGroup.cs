using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.ActionRules;

internal class ListByResourceGroupOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type NestedItemType() => typeof(ActionRuleModel);

    public override Type? OptionsObject() => typeof(ListByResourceGroupOperation.ListByResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.AlertsManagement/actionRules";

    internal class ListByResourceGroupOptions
    {
        [QueryStringName("actionGroup")]
        [Optional]
        public string ActionGroup { get; set; }

        [QueryStringName("alertRuleId")]
        [Optional]
        public string AlertRuleId { get; set; }

        [QueryStringName("description")]
        [Optional]
        public string Description { get; set; }

        [QueryStringName("impactedScope")]
        [Optional]
        public string ImpactedScope { get; set; }

        [QueryStringName("monitorService")]
        [Optional]
        public MonitorServiceConstant MonitorService { get; set; }

        [QueryStringName("name")]
        [Optional]
        public string Name { get; set; }

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
    }
}
