using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectionContainers;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationProtectionContainers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new DiscoverProtectableItemOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationFabricsOperation(),
        new SwitchProtectionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(A2AContainerCreationInputModel),
        typeof(A2ACrossClusterMigrationContainerCreationInputModel),
        typeof(A2ASwitchProtectionInputModel),
        typeof(A2AVMDiskInputDetailsModel),
        typeof(A2AVMManagedDiskInputDetailsModel),
        typeof(CreateProtectionContainerInputModel),
        typeof(CreateProtectionContainerInputPropertiesModel),
        typeof(DiscoverProtectableItemRequestModel),
        typeof(DiscoverProtectableItemRequestPropertiesModel),
        typeof(DiskEncryptionInfoModel),
        typeof(DiskEncryptionKeyInfoModel),
        typeof(KeyEncryptionKeyInfoModel),
        typeof(ProtectionContainerModel),
        typeof(ProtectionContainerFabricSpecificDetailsModel),
        typeof(ProtectionContainerPropertiesModel),
        typeof(ReplicationProviderSpecificContainerCreationInputModel),
        typeof(SwitchProtectionInputModel),
        typeof(SwitchProtectionInputPropertiesModel),
        typeof(SwitchProtectionProviderSpecificInputModel),
        typeof(VMwareCbtContainerCreationInputModel),
    };
}
