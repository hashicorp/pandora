using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_01_01.ReplicationProtectableItems;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationProtectableItems";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByReplicationProtectionContainersOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HealthErrorCustomerResolvabilityConstant),
        typeof(PresenceStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConfigurationSettingsModel),
        typeof(DiskDetailsModel),
        typeof(DiskVolumeDetailsModel),
        typeof(HealthErrorModel),
        typeof(HyperVVirtualMachineDetailsModel),
        typeof(InMageDiskDetailsModel),
        typeof(InnerHealthErrorModel),
        typeof(OSDetailsModel),
        typeof(ProtectableItemModel),
        typeof(ProtectableItemPropertiesModel),
        typeof(ReplicationGroupDetailsModel),
        typeof(VMmVirtualMachineDetailsModel),
        typeof(VMwareVirtualMachineDetailsModel),
    };
}
