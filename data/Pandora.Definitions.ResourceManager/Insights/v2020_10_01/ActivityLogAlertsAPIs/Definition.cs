using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2020_10_01.ActivityLogAlertsAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "ActivityLogAlertsAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ActivityLogAlertsCreateOrUpdateOperation(),
        new ActivityLogAlertsDeleteOperation(),
        new ActivityLogAlertsGetOperation(),
        new ActivityLogAlertsListByResourceGroupOperation(),
        new ActivityLogAlertsListBySubscriptionIdOperation(),
        new ActivityLogAlertsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionGroupModel),
        typeof(ActionListModel),
        typeof(ActivityLogAlertResourceModel),
        typeof(AlertRuleAllOfConditionModel),
        typeof(AlertRuleAnyOfOrLeafConditionModel),
        typeof(AlertRuleLeafConditionModel),
        typeof(AlertRulePatchObjectModel),
        typeof(AlertRulePatchPropertiesModel),
        typeof(AlertRulePropertiesModel),
    };
}
