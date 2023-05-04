using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.ProtectionIntent;

internal class Definition : ResourceDefinition
{
    public string Name => "ProtectionIntent";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ValidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackupManagementTypeConstant),
        typeof(DataSourceTypeConstant),
        typeof(ProtectionIntentItemTypeConstant),
        typeof(ProtectionStatusConstant),
        typeof(ValidationStatusConstant),
        typeof(WorkloadItemTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureRecoveryServiceVaultProtectionIntentModel),
        typeof(AzureResourceProtectionIntentModel),
        typeof(AzureWorkloadAutoProtectionIntentModel),
        typeof(AzureWorkloadContainerAutoProtectionIntentModel),
        typeof(AzureWorkloadSQLAutoProtectionIntentModel),
        typeof(PreValidateEnableBackupRequestModel),
        typeof(PreValidateEnableBackupResponseModel),
        typeof(ProtectionIntentModel),
        typeof(ProtectionIntentResourceModel),
    };
}
