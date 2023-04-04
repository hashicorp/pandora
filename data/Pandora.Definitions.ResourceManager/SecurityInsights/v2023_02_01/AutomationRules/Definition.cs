using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.AutomationRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AutomationRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionTypeConstant),
        typeof(AutomationRulePropertyArrayChangedConditionSupportedArrayTypeConstant),
        typeof(AutomationRulePropertyArrayChangedConditionSupportedChangeTypeConstant),
        typeof(AutomationRulePropertyChangedConditionSupportedChangedTypeConstant),
        typeof(AutomationRulePropertyChangedConditionSupportedPropertyTypeConstant),
        typeof(AutomationRulePropertyConditionSupportedOperatorConstant),
        typeof(AutomationRulePropertyConditionSupportedPropertyConstant),
        typeof(ConditionTypeConstant),
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
        typeof(AutomationRulePropertiesModel),
        typeof(AutomationRulePropertyArrayChangedValuesConditionModel),
        typeof(AutomationRulePropertyValuesChangedConditionModel),
        typeof(AutomationRulePropertyValuesConditionModel),
        typeof(AutomationRuleRunPlaybookActionModel),
        typeof(AutomationRuleTriggeringLogicModel),
        typeof(ClientInfoModel),
        typeof(IncidentLabelModel),
        typeof(IncidentOwnerInfoModel),
        typeof(IncidentPropertiesActionModel),
        typeof(PlaybookActionPropertiesModel),
        typeof(PropertyArrayChangedConditionPropertiesModel),
        typeof(PropertyChangedConditionPropertiesModel),
        typeof(PropertyConditionPropertiesModel),
    };
}
