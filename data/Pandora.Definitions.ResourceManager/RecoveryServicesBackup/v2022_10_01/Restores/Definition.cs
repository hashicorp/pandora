using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.Restores;

internal class Definition : ResourceDefinition
{
    public string Name => "Restores";
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
        typeof(RehydrationPriorityConstant),
        typeof(RestoreRequestTypeConstant),
        typeof(SQLDataDirectoryTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureFileShareRestoreRequestModel),
        typeof(AzureWorkloadPointInTimeRestoreRequestModel),
        typeof(AzureWorkloadRestoreRequestModel),
        typeof(AzureWorkloadSAPHanaRestoreRequestModel),
        typeof(AzureWorkloadSQLRestoreRequestModel),
        typeof(EncryptionDetailsModel),
        typeof(IaasVMRestoreRequestModel),
        typeof(IaasVMRestoreWithRehydrationRequestModel),
        typeof(IdentityBasedRestoreDetailsModel),
        typeof(IdentityInfoModel),
        typeof(RecoveryPointRehydrationInfoModel),
        typeof(RestoreFileSpecsModel),
        typeof(RestoreRequestModel),
        typeof(RestoreRequestResourceModel),
        typeof(SQLDataDirectoryMappingModel),
        typeof(TargetAFSRestoreInfoModel),
        typeof(TargetRestoreInfoModel),
    };
}
