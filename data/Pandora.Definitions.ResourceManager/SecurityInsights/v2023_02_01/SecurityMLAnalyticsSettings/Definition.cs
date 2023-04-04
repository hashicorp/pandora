using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.SecurityMLAnalyticsSettings;

internal class Definition : ResourceDefinition
{
    public string Name => "SecurityMLAnalyticsSettings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SecurityMLAnalyticsSettingsCreateOrUpdateOperation(),
        new SecurityMLAnalyticsSettingsDeleteOperation(),
        new SecurityMLAnalyticsSettingsGetOperation(),
        new SecurityMLAnalyticsSettingsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AttackTacticConstant),
        typeof(SecurityMLAnalyticsSettingsKindConstant),
        typeof(SettingsStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AnomalySecurityMLAnalyticsSettingsModel),
        typeof(AnomalySecurityMLAnalyticsSettingsPropertiesModel),
        typeof(SecurityMLAnalyticsSettingModel),
        typeof(SecurityMLAnalyticsSettingsDataSourceModel),
    };
}
