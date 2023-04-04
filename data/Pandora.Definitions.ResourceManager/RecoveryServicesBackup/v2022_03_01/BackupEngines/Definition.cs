using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupEngines;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupEngines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackupEngineTypeConstant),
        typeof(BackupManagementTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureBackupServerEngineModel),
        typeof(BackupEngineBaseModel),
        typeof(BackupEngineBaseResourceModel),
        typeof(BackupEngineExtendedInfoModel),
        typeof(DpmBackupEngineModel),
    };
}
