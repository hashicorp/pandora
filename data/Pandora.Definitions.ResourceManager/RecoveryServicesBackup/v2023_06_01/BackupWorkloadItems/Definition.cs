using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.BackupWorkloadItems;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupWorkloadItems";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProtectionStatusConstant),
        typeof(SQLDataDirectoryTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureVMWorkloadItemModel),
        typeof(AzureVMWorkloadSAPAseDatabaseWorkloadItemModel),
        typeof(AzureVMWorkloadSAPAseSystemWorkloadItemModel),
        typeof(AzureVMWorkloadSAPHanaDatabaseWorkloadItemModel),
        typeof(AzureVMWorkloadSAPHanaSystemWorkloadItemModel),
        typeof(AzureVMWorkloadSQLDatabaseWorkloadItemModel),
        typeof(AzureVMWorkloadSQLInstanceWorkloadItemModel),
        typeof(SQLDataDirectoryModel),
        typeof(WorkloadItemModel),
        typeof(WorkloadItemResourceModel),
    };
}
