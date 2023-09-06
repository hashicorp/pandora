using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.AutomationRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AutomationRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AutomationRuleActionTypeConstant),
        typeof(AutomationRuleConditionTypeConstant),
        typeof(AutomationRulePropertyConditionSupportedOperatorConstant),
        typeof(AutomationRulePropertyConditionSupportedPropertyConstant),
        typeof(IncidentClassificationConstant),
        typeof(IncidentClassificationReasonConstant),
        typeof(IncidentLabelTypeConstant),
        typeof(IncidentSeverityConstant),
        typeof(IncidentStatusConstant),
        typeof(OwnerTypeConstant),
        typeof(TriggersOnConstant),
        typeof(TriggersWhenConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutomationRuleModel),
        typeof(AutomationRuleActionModel),
        typeof(AutomationRuleConditionModel),
        typeof(AutomationRuleModifyPropertiesActionModel),
        typeof(AutomationRuleModifyPropertiesActionActionConfigurationModel),
        typeof(AutomationRulePropertiesModel),
        typeof(AutomationRulePropertyValuesConditionModel),
        typeof(AutomationRulePropertyValuesConditionConditionPropertiesModel),
        typeof(AutomationRuleRunPlaybookActionModel),
        typeof(AutomationRuleRunPlaybookActionActionConfigurationModel),
        typeof(AutomationRuleTriggeringLogicModel),
        typeof(ClientInfoModel),
        typeof(IncidentLabelModel),
        typeof(IncidentOwnerInfoModel),
    };
}
