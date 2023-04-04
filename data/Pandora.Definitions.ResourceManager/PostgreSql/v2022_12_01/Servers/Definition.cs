using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_12_01.Servers;

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
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActiveDirectoryAuthEnumConstant),
        typeof(ArmServerKeyTypeConstant),
        typeof(CreateModeConstant),
        typeof(CreateModeForUpdateConstant),
        typeof(GeoRedundantBackupEnumConstant),
        typeof(HighAvailabilityModeConstant),
        typeof(IdentityTypeConstant),
        typeof(PasswordAuthEnumConstant),
        typeof(ReplicationRoleConstant),
        typeof(ServerHAStateConstant),
        typeof(ServerPublicNetworkAccessStateConstant),
        typeof(ServerStateConstant),
        typeof(ServerVersionConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthConfigModel),
        typeof(BackupModel),
        typeof(DataEncryptionModel),
        typeof(HighAvailabilityModel),
        typeof(MaintenanceWindowModel),
        typeof(NetworkModel),
        typeof(ServerModel),
        typeof(ServerForUpdateModel),
        typeof(ServerPropertiesModel),
        typeof(ServerPropertiesForUpdateModel),
        typeof(SkuModel),
        typeof(StorageModel),
        typeof(UserAssignedIdentityModel),
        typeof(UserIdentityModel),
    };
}
