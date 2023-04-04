using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupProtectedItems;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupProtectedItems";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackupManagementTypeConstant),
        typeof(CreateModeConstant),
        typeof(DataSourceTypeConstant),
        typeof(HealthStatusConstant),
        typeof(LastBackupStatusConstant),
        typeof(ProtectedItemHealthStatusConstant),
        typeof(ProtectedItemStateConstant),
        typeof(ProtectionStateConstant),
        typeof(ResourceHealthStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureFileshareProtectedItemModel),
        typeof(AzureFileshareProtectedItemExtendedInfoModel),
        typeof(AzureIaaSClassicComputeVMProtectedItemModel),
        typeof(AzureIaaSComputeVMProtectedItemModel),
        typeof(AzureIaaSVMProtectedItemModel),
        typeof(AzureIaaSVMProtectedItemExtendedInfoModel),
        typeof(AzureSqlProtectedItemModel),
        typeof(AzureSqlProtectedItemExtendedInfoModel),
        typeof(AzureVMWorkloadProtectedItemModel),
        typeof(AzureVMWorkloadProtectedItemExtendedInfoModel),
        typeof(AzureVMWorkloadSAPAseDatabaseProtectedItemModel),
        typeof(AzureVMWorkloadSAPHanaDatabaseProtectedItemModel),
        typeof(AzureVMWorkloadSQLDatabaseProtectedItemModel),
        typeof(DPMProtectedItemModel),
        typeof(DPMProtectedItemExtendedInfoModel),
        typeof(DiskExclusionPropertiesModel),
        typeof(ErrorDetailModel),
        typeof(ExtendedPropertiesModel),
        typeof(GenericProtectedItemModel),
        typeof(KPIResourceHealthDetailsModel),
        typeof(MabFileFolderProtectedItemModel),
        typeof(MabFileFolderProtectedItemExtendedInfoModel),
        typeof(ProtectedItemModel),
        typeof(ProtectedItemResourceModel),
        typeof(ResourceHealthDetailsModel),
    };
}
