using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_04_16.ScheduledQueryRules;

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
        typeof(ConditionalOperatorConstant),
        typeof(EnabledConstant),
        typeof(MetricTriggerTypeConstant),
        typeof(OperatorConstant),
        typeof(ProvisioningStateConstant),
        typeof(QueryTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionModel),
        typeof(AlertingActionModel),
        typeof(AzNsActionGroupModel),
        typeof(CriteriaModel),
        typeof(DimensionModel),
        typeof(LogMetricTriggerModel),
        typeof(LogSearchRuleModel),
        typeof(LogSearchRulePatchModel),
        typeof(LogSearchRuleResourceModel),
        typeof(LogSearchRuleResourceCollectionModel),
        typeof(LogSearchRuleResourcePatchModel),
        typeof(LogToMetricActionModel),
        typeof(ScheduleModel),
        typeof(SourceModel),
        typeof(TriggerConditionModel),
    };
}
