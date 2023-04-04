using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertProcessingRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AlertProcessingRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AlertProcessingRulesCreateOrUpdateOperation(),
        new AlertProcessingRulesDeleteOperation(),
        new AlertProcessingRulesGetByNameOperation(),
        new AlertProcessingRulesListByResourceGroupOperation(),
        new AlertProcessingRulesListBySubscriptionOperation(),
        new AlertProcessingRulesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionTypeConstant),
        typeof(DaysOfWeekConstant),
        typeof(FieldConstant),
        typeof(OperatorConstant),
        typeof(RecurrenceTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionModel),
        typeof(AddActionGroupsModel),
        typeof(AlertProcessingRuleModel),
        typeof(AlertProcessingRulePropertiesModel),
        typeof(ConditionModel),
        typeof(DailyRecurrenceModel),
        typeof(MonthlyRecurrenceModel),
        typeof(PatchObjectModel),
        typeof(PatchPropertiesModel),
        typeof(RecurrenceModel),
        typeof(RemoveAllActionGroupsModel),
        typeof(ScheduleModel),
        typeof(WeeklyRecurrenceModel),
    };
}
