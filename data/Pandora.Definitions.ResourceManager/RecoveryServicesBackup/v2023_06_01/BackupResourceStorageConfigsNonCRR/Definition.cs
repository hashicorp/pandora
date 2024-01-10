using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.BackupResourceStorageConfigsNonCRR;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupResourceStorageConfigsNonCRR";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new PatchOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DedupStateConstant),
        typeof(StorageTypeConstant),
        typeof(StorageTypeStateConstant),
        typeof(XcoolStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupResourceConfigModel),
        typeof(BackupResourceConfigResourceModel),
    };
}
