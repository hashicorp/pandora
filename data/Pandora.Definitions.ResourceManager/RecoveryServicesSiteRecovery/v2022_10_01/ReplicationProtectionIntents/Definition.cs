using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectionIntents;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationProtectionIntents";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(A2ARecoveryAvailabilityTypeConstant),
        typeof(AgentAutoUpdateStatusConstant),
        typeof(AutoProtectionOfDataDiskConstant),
        typeof(AutomationAccountAuthenticationTypeConstant),
        typeof(SetMultiVMSyncStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(A2ACreateProtectionIntentInputModel),
        typeof(A2AProtectionIntentDiskInputDetailsModel),
        typeof(A2AProtectionIntentManagedDiskInputDetailsModel),
        typeof(A2AReplicationIntentDetailsModel),
        typeof(CreateProtectionIntentInputModel),
        typeof(CreateProtectionIntentPropertiesModel),
        typeof(CreateProtectionIntentProviderSpecificDetailsModel),
        typeof(DiskEncryptionInfoModel),
        typeof(DiskEncryptionKeyInfoModel),
        typeof(ExistingProtectionProfileModel),
        typeof(ExistingRecoveryAvailabilitySetModel),
        typeof(ExistingRecoveryProximityPlacementGroupModel),
        typeof(ExistingRecoveryRecoveryResourceGroupModel),
        typeof(ExistingRecoveryVirtualNetworkModel),
        typeof(ExistingStorageAccountModel),
        typeof(KeyEncryptionKeyInfoModel),
        typeof(NewProtectionProfileModel),
        typeof(NewRecoveryVirtualNetworkModel),
        typeof(ProtectionProfileCustomDetailsModel),
        typeof(RecoveryAvailabilitySetCustomDetailsModel),
        typeof(RecoveryProximityPlacementGroupCustomDetailsModel),
        typeof(RecoveryResourceGroupCustomDetailsModel),
        typeof(RecoveryVirtualNetworkCustomDetailsModel),
        typeof(ReplicationProtectionIntentModel),
        typeof(ReplicationProtectionIntentPropertiesModel),
        typeof(ReplicationProtectionIntentProviderSpecificSettingsModel),
        typeof(StorageAccountCustomDetailsModel),
    };
}
