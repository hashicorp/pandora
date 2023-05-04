using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.Operation;

internal class Definition : ResourceDefinition
{
    public string Name => "Operation";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ValidateOperation(),
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
        typeof(AzureWorkloadSAPHanaPointInTimeRestoreRequestModel),
        typeof(AzureWorkloadSAPHanaPointInTimeRestoreWithRehydrateRequestModel),
        typeof(AzureWorkloadSAPHanaRestoreRequestModel),
        typeof(AzureWorkloadSAPHanaRestoreWithRehydrateRequestModel),
        typeof(AzureWorkloadSQLPointInTimeRestoreRequestModel),
        typeof(AzureWorkloadSQLPointInTimeRestoreWithRehydrateRequestModel),
        typeof(AzureWorkloadSQLRestoreRequestModel),
        typeof(AzureWorkloadSQLRestoreWithRehydrateRequestModel),
        typeof(EncryptionDetailsModel),
        typeof(ErrorDetailModel),
        typeof(IaasVMRestoreRequestModel),
        typeof(IaasVMRestoreWithRehydrationRequestModel),
        typeof(IdentityBasedRestoreDetailsModel),
        typeof(IdentityInfoModel),
        typeof(RecoveryPointRehydrationInfoModel),
        typeof(RestoreFileSpecsModel),
        typeof(RestoreRequestModel),
        typeof(SQLDataDirectoryMappingModel),
        typeof(TargetAFSRestoreInfoModel),
        typeof(TargetRestoreInfoModel),
        typeof(ValidateIaasVMRestoreOperationRequestModel),
        typeof(ValidateOperationRequestModel),
        typeof(ValidateOperationResponseModel),
        typeof(ValidateOperationsResponseModel),
        typeof(ValidateRestoreOperationRequestModel),
    };
}
