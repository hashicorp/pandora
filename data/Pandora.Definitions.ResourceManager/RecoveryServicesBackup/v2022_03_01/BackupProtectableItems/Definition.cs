using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupProtectableItems;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupProtectableItems";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AzureFileShareTypeConstant),
        typeof(InquiryStatusConstant),
        typeof(ProtectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureFileShareProtectableItemModel),
        typeof(AzureIaaSClassicComputeVMProtectableItemModel),
        typeof(AzureIaaSComputeVMProtectableItemModel),
        typeof(AzureVMWorkloadProtectableItemModel),
        typeof(AzureVMWorkloadSAPAseSystemProtectableItemModel),
        typeof(AzureVMWorkloadSAPHanaDatabaseProtectableItemModel),
        typeof(AzureVMWorkloadSAPHanaSystemProtectableItemModel),
        typeof(AzureVMWorkloadSQLAvailabilityGroupProtectableItemModel),
        typeof(AzureVMWorkloadSQLDatabaseProtectableItemModel),
        typeof(AzureVMWorkloadSQLInstanceProtectableItemModel),
        typeof(IaaSVMProtectableItemModel),
        typeof(PreBackupValidationModel),
        typeof(WorkloadProtectableItemModel),
        typeof(WorkloadProtectableItemResourceModel),
    };
}
