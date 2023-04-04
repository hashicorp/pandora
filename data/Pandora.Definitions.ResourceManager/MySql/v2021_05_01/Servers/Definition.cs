using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_05_01.Servers;

internal class Definition : ResourceDefinition
{
    public string Name => "Servers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ReplicasListByServerOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateModeConstant),
        typeof(DataEncryptionTypeConstant),
        typeof(EnableStatusEnumConstant),
        typeof(HighAvailabilityModeConstant),
        typeof(HighAvailabilityStateConstant),
        typeof(ManagedServiceIdentityTypeConstant),
        typeof(ReplicationRoleConstant),
        typeof(ServerStateConstant),
        typeof(ServerVersionConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupModel),
        typeof(DataEncryptionModel),
        typeof(HighAvailabilityModel),
        typeof(IdentityModel),
        typeof(MaintenanceWindowModel),
        typeof(NetworkModel),
        typeof(ServerModel),
        typeof(ServerForUpdateModel),
        typeof(ServerPropertiesModel),
        typeof(ServerPropertiesForUpdateModel),
        typeof(SkuModel),
        typeof(StorageModel),
    };
}
