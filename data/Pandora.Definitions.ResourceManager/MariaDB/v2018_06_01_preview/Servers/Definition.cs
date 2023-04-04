using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview.Servers;

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
        typeof(GeoRedundantBackupConstant),
        typeof(MinimalTlsVersionEnumConstant),
        typeof(ServerStateConstant),
        typeof(ServerVersionConstant),
        typeof(SkuTierConstant),
        typeof(SslEnforcementEnumConstant),
        typeof(StorageAutogrowConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ServerModel),
        typeof(ServerForCreateModel),
        typeof(ServerListResultModel),
        typeof(ServerPropertiesModel),
        typeof(ServerPropertiesForCreateModel),
        typeof(ServerPropertiesForDefaultCreateModel),
        typeof(ServerPropertiesForGeoRestoreModel),
        typeof(ServerPropertiesForReplicaModel),
        typeof(ServerPropertiesForRestoreModel),
        typeof(ServerUpdateParametersModel),
        typeof(ServerUpdateParametersPropertiesModel),
        typeof(SkuModel),
        typeof(StorageProfileModel),
    };
}
