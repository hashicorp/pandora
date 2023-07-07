using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Replicas;

internal class Definition : ResourceDefinition
{
    public string Name => "Replicas";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActiveDirectoryAuthEnumConstant),
        typeof(ArmServerKeyTypeConstant),
        typeof(AzureManagedDiskPerformanceTiersConstant),
        typeof(CreateModeConstant),
        typeof(GeoRedundantBackupEnumConstant),
        typeof(HighAvailabilityModeConstant),
        typeof(KeyStatusEnumConstant),
        typeof(PasswordAuthEnumConstant),
        typeof(ReplicationRoleConstant),
        typeof(ServerHAStateConstant),
        typeof(ServerPublicNetworkAccessStateConstant),
        typeof(ServerStateConstant),
        typeof(ServerVersionConstant),
        typeof(SkuTierConstant),
        typeof(StorageAutoGrowConstant),
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
        typeof(ServerListResultModel),
        typeof(ServerPropertiesModel),
        typeof(SkuModel),
        typeof(StorageModel),
    };
}
