using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRulesAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "AlertRulesAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AlertRulesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConditionOperatorConstant),
        typeof(TimeAggregationOperatorConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AlertRuleModel),
        typeof(AlertRuleResourceModel),
        typeof(AlertRuleResourcePatchModel),
        typeof(LocationThresholdRuleConditionModel),
        typeof(ManagementEventAggregationConditionModel),
        typeof(ManagementEventRuleConditionModel),
        typeof(RuleActionModel),
        typeof(RuleConditionModel),
        typeof(RuleDataSourceModel),
        typeof(RuleEmailActionModel),
        typeof(RuleManagementEventClaimsDataSourceModel),
        typeof(RuleManagementEventDataSourceModel),
        typeof(RuleMetricDataSourceModel),
        typeof(RuleWebhookActionModel),
        typeof(ThresholdRuleConditionModel),
    };
}
