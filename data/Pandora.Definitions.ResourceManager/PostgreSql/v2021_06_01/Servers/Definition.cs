using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2021_06_01.Servers;

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
        typeof(CreateModeConstant),
        typeof(CreateModeForUpdateConstant),
        typeof(GeoRedundantBackupEnumConstant),
        typeof(HighAvailabilityModeConstant),
        typeof(ServerHAStateConstant),
        typeof(ServerPublicNetworkAccessStateConstant),
        typeof(ServerStateConstant),
        typeof(ServerVersionConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupModel),
        typeof(HighAvailabilityModel),
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
