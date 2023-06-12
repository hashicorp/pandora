using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationVaultSetting;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationVaultSetting";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(VaultSettingModel),
        typeof(VaultSettingCreationInputModel),
        typeof(VaultSettingCreationInputPropertiesModel),
        typeof(VaultSettingPropertiesModel),
    };
}
