using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_03_01.ArcSettings;

internal class Definition : ResourceDefinition
{
    public string Name => "ArcSettings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ArcSettingsCreateOperation(),
        new ArcSettingsDeleteOperation(),
        new ArcSettingsGetOperation(),
        new ArcSettingsListByClusterOperation(),
        new ArcSettingsUpdateOperation(),
        new ConsentAndInstallDefaultExtensionsOperation(),
        new CreateIdentityOperation(),
        new GeneratePasswordOperation(),
        new InitializeDisableProcessOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ArcSettingAggregateStateConstant),
        typeof(NodeArcStateConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ArcIdentityResponseModel),
        typeof(ArcIdentityResponsePropertiesModel),
        typeof(ArcSettingModel),
        typeof(ArcSettingPropertiesModel),
        typeof(ArcSettingsPatchModel),
        typeof(ArcSettingsPatchPropertiesModel),
        typeof(DefaultExtensionDetailsModel),
        typeof(PasswordCredentialModel),
        typeof(PerNodeStateModel),
    };
}
