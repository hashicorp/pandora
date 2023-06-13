using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.CrrJobDetails;

internal class Definition : ResourceDefinition
{
    public string Name => "CrrJobDetails";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BackupCrrJobDetailsGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackupManagementTypeConstant),
        typeof(JobSupportedActionConstant),
        typeof(MabServerTypeConstant),
        typeof(WorkloadTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureIaaSVMErrorInfoModel),
        typeof(AzureIaaSVMJobModel),
        typeof(AzureIaaSVMJobExtendedInfoModel),
        typeof(AzureIaaSVMJobTaskDetailsModel),
        typeof(AzureStorageErrorInfoModel),
        typeof(AzureStorageJobModel),
        typeof(AzureStorageJobExtendedInfoModel),
        typeof(AzureStorageJobTaskDetailsModel),
        typeof(AzureWorkloadErrorInfoModel),
        typeof(AzureWorkloadJobModel),
        typeof(AzureWorkloadJobExtendedInfoModel),
        typeof(AzureWorkloadJobTaskDetailsModel),
        typeof(CrrJobRequestModel),
        typeof(DpmErrorInfoModel),
        typeof(DpmJobModel),
        typeof(DpmJobExtendedInfoModel),
        typeof(DpmJobTaskDetailsModel),
        typeof(JobModel),
        typeof(JobResourceModel),
        typeof(MabErrorInfoModel),
        typeof(MabJobModel),
        typeof(MabJobExtendedInfoModel),
        typeof(MabJobTaskDetailsModel),
    };
}
