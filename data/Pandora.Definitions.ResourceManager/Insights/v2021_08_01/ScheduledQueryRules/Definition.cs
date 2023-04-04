using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_08_01.ScheduledQueryRules;

internal class Definition : ResourceDefinition
{
    public string Name => "ScheduledQueryRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertSeverityConstant),
        typeof(ConditionOperatorConstant),
        typeof(DimensionOperatorConstant),
        typeof(KindConstant),
        typeof(TimeAggregationConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionsModel),
        typeof(ConditionModel),
        typeof(ConditionFailingPeriodsModel),
        typeof(DimensionModel),
        typeof(ScheduledQueryRuleCriteriaModel),
        typeof(ScheduledQueryRulePropertiesModel),
        typeof(ScheduledQueryRuleResourceModel),
        typeof(ScheduledQueryRuleResourcePatchModel),
    };
}
