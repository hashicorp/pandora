using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.CrossRegionRestore;

internal class Definition : ResourceDefinition
{
    public string Name => "CrossRegionRestore";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TriggerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CopyOptionsConstant),
        typeof(OverwriteOptionsConstant),
        typeof(RecoveryModeConstant),
        typeof(RecoveryTypeConstant),
        typeof(RestoreRequestTypeConstant),
        typeof(SQLDataDirectoryTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureFileShareRestoreRequestModel),
        typeof(AzureWorkloadPointInTimeRestoreRequestModel),
        typeof(AzureWorkloadRestoreRequestModel),
        typeof(AzureWorkloadSAPHanaPointInTimeRestoreRequestModel),
        typeof(AzureWorkloadSAPHanaRestoreRequestModel),
        typeof(AzureWorkloadSQLPointInTimeRestoreRequestModel),
        typeof(AzureWorkloadSQLRestoreRequestModel),
        typeof(CrossRegionRestoreRequestModel),
        typeof(CrrAccessTokenModel),
        typeof(EncryptionDetailsModel),
        typeof(IaasVMRestoreRequestModel),
        typeof(IdentityBasedRestoreDetailsModel),
        typeof(IdentityInfoModel),
        typeof(RestoreFileSpecsModel),
        typeof(RestoreRequestModel),
        typeof(SQLDataDirectoryMappingModel),
        typeof(TargetAFSRestoreInfoModel),
        typeof(TargetRestoreInfoModel),
        typeof(WorkloadCrrAccessTokenModel),
    };
}
