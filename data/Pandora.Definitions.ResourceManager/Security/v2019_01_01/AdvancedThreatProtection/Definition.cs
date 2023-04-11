using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01.AdvancedThreatProtection;

internal class Definition : ResourceDefinition
{
    public string Name => "AdvancedThreatProtection";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SettingNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdvancedThreatProtectionPropertiesModel),
        typeof(AdvancedThreatProtectionSettingModel),
    };
}
