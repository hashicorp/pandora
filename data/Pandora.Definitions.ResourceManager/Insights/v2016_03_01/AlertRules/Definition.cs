using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AlertRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
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
        typeof(AlertRuleResourceCollectionModel),
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
