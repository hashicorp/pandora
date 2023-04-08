using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.AutoProvisioningSettings;

internal class Definition : ResourceDefinition
{
    public string Name => "AutoProvisioningSettings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AutoProvisionConstant),
        typeof(InformationProtectionPolicyNameConstant),
        typeof(SettingNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoProvisioningSettingModel),
        typeof(AutoProvisioningSettingPropertiesModel),
    };
}
