using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.DeviceSecurityGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "DeviceSecurityGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(InformationProtectionPolicyNameConstant),
        typeof(SettingNameConstant),
        typeof(ValueTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AllowlistCustomAlertRuleModel),
        typeof(DenylistCustomAlertRuleModel),
        typeof(DeviceSecurityGroupModel),
        typeof(DeviceSecurityGroupPropertiesModel),
        typeof(ThresholdCustomAlertRuleModel),
        typeof(TimeWindowCustomAlertRuleModel),
    };
}
