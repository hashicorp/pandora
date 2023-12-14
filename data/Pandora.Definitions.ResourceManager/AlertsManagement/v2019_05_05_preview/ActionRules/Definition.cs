using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.ActionRules;

internal class Definition : ResourceDefinition
{
    public string Name => "ActionRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateOperation(),
        new DeleteOperation(),
        new GetByNameOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionRuleStatusConstant),
        typeof(ActionRuleTypeConstant),
        typeof(MonitorServiceConstant),
        typeof(OperatorConstant),
        typeof(ScopeTypeConstant),
        typeof(SeverityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionRuleModel),
        typeof(ActionRulePropertiesModel),
        typeof(ConditionModel),
        typeof(ConditionsModel),
        typeof(PatchObjectModel),
        typeof(PatchPropertiesModel),
        typeof(ScopeModel),
    };
}
