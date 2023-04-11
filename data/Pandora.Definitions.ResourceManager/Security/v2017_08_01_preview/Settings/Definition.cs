using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.Settings;

internal class Definition : ResourceDefinition
{
    public string Name => "Settings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(InformationProtectionPolicyNameConstant),
        typeof(SettingKindConstant),
        typeof(SettingNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataExportSettingModel),
        typeof(DataExportSettingPropertiesModel),
        typeof(SettingModel),
    };
}
