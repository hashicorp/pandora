using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_06_01.SmartDetectorAlertRules;

internal class Definition : ResourceDefinition
{
    public string Name => "SmartDetectorAlertRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new PatchOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertRuleStateConstant),
        typeof(SeverityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionGroupsInformationModel),
        typeof(AlertRuleModel),
        typeof(AlertRulePatchObjectModel),
        typeof(AlertRulePatchPropertiesModel),
        typeof(AlertRulePropertiesModel),
        typeof(DetectorModel),
        typeof(ThrottlingInformationModel),
    };
}
