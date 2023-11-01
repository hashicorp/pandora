using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.ProtectionContainers;

internal class Definition : ResourceDefinition
{
    public string Name => "ProtectionContainers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new InquireOperation(),
        new RefreshOperation(),
        new RegisterOperation(),
        new UnregisterOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AcquireStorageAccountLockConstant),
        typeof(BackupItemTypeConstant),
        typeof(BackupManagementTypeConstant),
        typeof(OperationTypeConstant),
        typeof(ProtectableContainerTypeConstant),
        typeof(WorkloadTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureBackupServerContainerModel),
        typeof(AzureIaaSClassicComputeVMContainerModel),
        typeof(AzureIaaSComputeVMContainerModel),
        typeof(AzureSQLAGWorkloadContainerProtectionContainerModel),
        typeof(AzureSqlContainerModel),
        typeof(AzureStorageContainerModel),
        typeof(AzureVMAppContainerProtectionContainerModel),
        typeof(AzureWorkloadContainerModel),
        typeof(AzureWorkloadContainerExtendedInfoModel),
        typeof(ContainerIdentityInfoModel),
        typeof(DPMContainerExtendedInfoModel),
        typeof(DistributedNodesInfoModel),
        typeof(DpmContainerModel),
        typeof(ErrorDetailModel),
        typeof(GenericContainerModel),
        typeof(GenericContainerExtendedInfoModel),
        typeof(IaaSVMContainerModel),
        typeof(InquiryInfoModel),
        typeof(InquiryValidationModel),
        typeof(MABContainerHealthDetailsModel),
        typeof(MabContainerModel),
        typeof(MabContainerExtendedInfoModel),
        typeof(ProtectionContainerModel),
        typeof(ProtectionContainerResourceModel),
        typeof(WorkloadInquiryDetailsModel),
    };
}
