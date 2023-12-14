using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.BackupProtectionIntent;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupProtectionIntent";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackupManagementTypeConstant),
        typeof(ProtectionIntentItemTypeConstant),
        typeof(ProtectionStatusConstant),
        typeof(WorkloadItemTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureRecoveryServiceVaultProtectionIntentModel),
        typeof(AzureResourceProtectionIntentModel),
        typeof(AzureWorkloadAutoProtectionIntentModel),
        typeof(AzureWorkloadContainerAutoProtectionIntentModel),
        typeof(AzureWorkloadSQLAutoProtectionIntentModel),
        typeof(ProtectionIntentModel),
        typeof(ProtectionIntentResourceModel),
    };
}
