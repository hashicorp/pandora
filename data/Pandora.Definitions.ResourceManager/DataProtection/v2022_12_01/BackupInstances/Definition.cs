using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AdhocBackupOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ResumeBackupsOperation(),
        new ResumeProtectionOperation(),
        new StopProtectionOperation(),
        new SuspendBackupsOperation(),
        new SyncBackupInstanceOperation(),
        new TriggerRehydrateOperation(),
        new TriggerRestoreOperation(),
        new ValidateForBackupOperation(),
        new ValidateForRestoreOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CurrentProtectionStateConstant),
        typeof(DataStoreTypesConstant),
        typeof(RecoveryOptionConstant),
        typeof(RehydrationPriorityConstant),
        typeof(RestoreTargetLocationTypeConstant),
        typeof(SecretStoreTypeConstant),
        typeof(SourceDataStoreTypeConstant),
        typeof(StatusConstant),
        typeof(SyncTypeConstant),
        typeof(ValidationTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdHocBackupRuleOptionsModel),
        typeof(AdhocBackupTriggerOptionModel),
        typeof(AuthCredentialsModel),
        typeof(AzureBackupRecoveryPointBasedRestoreRequestModel),
        typeof(AzureBackupRecoveryTimeBasedRestoreRequestModel),
        typeof(AzureBackupRehydrationRequestModel),
        typeof(AzureBackupRestoreRequestModel),
        typeof(AzureBackupRestoreWithRehydrationRequestModel),
        typeof(AzureOperationalStoreParametersModel),
        typeof(BackupInstanceModel),
        typeof(BackupInstanceResourceModel),
        typeof(DataStoreParametersModel),
        typeof(DatasourceModel),
        typeof(DatasourceSetModel),
        typeof(InnerErrorModel),
        typeof(ItemLevelRestoreCriteriaModel),
        typeof(ItemLevelRestoreTargetInfoModel),
        typeof(KubernetesPVRestoreCriteriaModel),
        typeof(KubernetesStorageClassRestoreCriteriaModel),
        typeof(OperationExtendedInfoModel),
        typeof(OperationJobExtendedInfoModel),
        typeof(PolicyInfoModel),
        typeof(PolicyParametersModel),
        typeof(ProtectionStatusDetailsModel),
        typeof(RangeBasedItemLevelRestoreCriteriaModel),
        typeof(RestoreFilesTargetInfoModel),
        typeof(RestoreTargetInfoModel),
        typeof(RestoreTargetInfoBaseModel),
        typeof(SecretStoreBasedAuthCredentialsModel),
        typeof(SecretStoreResourceModel),
        typeof(SyncBackupInstanceRequestModel),
        typeof(TargetDetailsModel),
        typeof(TriggerBackupRequestModel),
        typeof(UserFacingErrorModel),
        typeof(ValidateForBackupRequestModel),
        typeof(ValidateRestoreRequestObjectModel),
    };
}
