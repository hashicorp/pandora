using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.BackupRestore;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupRestore";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CloudEndpointsPostBackupOperation(),
        new CloudEndpointsPostRestoreOperation(),
        new CloudEndpointsPreBackupOperation(),
        new CloudEndpointsPreRestoreOperation(),
        new CloudEndpointsrestoreheartbeatOperation(),
    };
}
