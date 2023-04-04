using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Settings;

internal class Definition : ResourceDefinition
{
    public string Name => "Settings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ProductSettingsDeleteOperation(),
        new ProductSettingsGetOperation(),
        new ProductSettingsListOperation(),
        new ProductSettingsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EntityProvidersConstant),
        typeof(SettingKindConstant),
        typeof(UebaDataSourcesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AnomaliesModel),
        typeof(AnomaliesSettingsPropertiesModel),
        typeof(EntityAnalyticsModel),
        typeof(EntityAnalyticsPropertiesModel),
        typeof(EyesOnModel),
        typeof(EyesOnSettingsPropertiesModel),
        typeof(SettingListModel),
        typeof(SettingsModel),
        typeof(UebaModel),
        typeof(UebaPropertiesModel),
    };
}
