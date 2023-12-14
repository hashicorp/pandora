using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.AdvancedThreatProtectionSettings;

internal class Definition : ResourceDefinition
{
    public string Name => "AdvancedThreatProtectionSettings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServerThreatProtectionSettingsCreateOrUpdateOperation(),
        new ServerThreatProtectionSettingsGetOperation(),
        new ServerThreatProtectionSettingsListByServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ThreatProtectionStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ServerThreatProtectionPropertiesModel),
        typeof(ServerThreatProtectionSettingsModelModel),
    };
}
