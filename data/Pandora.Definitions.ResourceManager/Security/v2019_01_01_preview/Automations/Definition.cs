using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.Automations;

internal class Definition : ResourceDefinition
{
    public string Name => "Automations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ValidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionTypeConstant),
        typeof(EventSourceConstant),
        typeof(OperatorConstant),
        typeof(PropertyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutomationModel),
        typeof(AutomationActionModel),
        typeof(AutomationActionEventHubModel),
        typeof(AutomationActionLogicAppModel),
        typeof(AutomationActionWorkspaceModel),
        typeof(AutomationPropertiesModel),
        typeof(AutomationRuleSetModel),
        typeof(AutomationScopeModel),
        typeof(AutomationSourceModel),
        typeof(AutomationTriggeringRuleModel),
        typeof(AutomationValidationStatusModel),
    };
}
