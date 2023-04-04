using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SetMultiVMSyncStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(A2ACrossClusterMigrationPolicyCreationInputModel),
        typeof(A2APolicyCreationInputModel),
        typeof(A2APolicyDetailsModel),
        typeof(CreatePolicyInputModel),
        typeof(CreatePolicyInputPropertiesModel),
        typeof(HyperVReplicaAzurePolicyDetailsModel),
        typeof(HyperVReplicaAzurePolicyInputModel),
        typeof(HyperVReplicaBasePolicyDetailsModel),
        typeof(HyperVReplicaBluePolicyDetailsModel),
        typeof(HyperVReplicaBluePolicyInputModel),
        typeof(HyperVReplicaPolicyDetailsModel),
        typeof(HyperVReplicaPolicyInputModel),
        typeof(InMageAzureV2PolicyDetailsModel),
        typeof(InMageAzureV2PolicyInputModel),
        typeof(InMageBasePolicyDetailsModel),
        typeof(InMagePolicyDetailsModel),
        typeof(InMagePolicyInputModel),
        typeof(InMageRcmFailbackPolicyCreationInputModel),
        typeof(InMageRcmFailbackPolicyDetailsModel),
        typeof(InMageRcmPolicyCreationInputModel),
        typeof(InMageRcmPolicyDetailsModel),
        typeof(PolicyModel),
        typeof(PolicyPropertiesModel),
        typeof(PolicyProviderSpecificDetailsModel),
        typeof(PolicyProviderSpecificInputModel),
        typeof(UpdatePolicyInputModel),
        typeof(UpdatePolicyInputPropertiesModel),
        typeof(VMwareCbtPolicyCreationInputModel),
        typeof(VMwareCbtPolicyDetailsModel),
    };
}
