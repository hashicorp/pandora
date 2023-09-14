using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupStatus;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupStatus";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AcquireStorageAccountLockConstant),
        typeof(DataSourceTypeConstant),
        typeof(FabricNameConstant),
        typeof(ProtectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupStatusRequestModel),
        typeof(BackupStatusResponseModel),
    };
}
