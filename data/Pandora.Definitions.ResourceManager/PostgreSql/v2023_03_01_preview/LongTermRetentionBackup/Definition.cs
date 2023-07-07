using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.LongTermRetentionBackup;

internal class Definition : ResourceDefinition
{
    public string Name => "LongTermRetentionBackup";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new FlexibleServerStartLtrBackupOperation(),
        new FlexibleServerTriggerLtrPreBackupOperation(),
        new LtrBackupOperationsGetOperation(),
        new LtrBackupOperationsListByServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExecutionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupRequestBaseModel),
        typeof(BackupSettingsModel),
        typeof(BackupStoreDetailsModel),
        typeof(LtrBackupOperationResponsePropertiesModel),
        typeof(LtrBackupRequestModel),
        typeof(LtrBackupResponseModel),
        typeof(LtrPreBackupResponseModel),
        typeof(LtrPreBackupResponsePropertiesModel),
        typeof(LtrServerBackupOperationModel),
    };
}
