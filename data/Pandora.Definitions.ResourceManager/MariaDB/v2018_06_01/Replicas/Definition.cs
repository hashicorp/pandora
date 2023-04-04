using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.Replicas;

internal class Definition : ResourceDefinition
{
    public string Name => "Replicas";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(GeoRedundantBackupConstant),
        typeof(MinimalTlsVersionEnumConstant),
        typeof(PrivateEndpointProvisioningStateConstant),
        typeof(PrivateLinkServiceConnectionStateActionsRequireConstant),
        typeof(PrivateLinkServiceConnectionStateStatusConstant),
        typeof(PublicNetworkAccessEnumConstant),
        typeof(ServerStateConstant),
        typeof(ServerVersionConstant),
        typeof(SkuTierConstant),
        typeof(SslEnforcementEnumConstant),
        typeof(StorageAutogrowConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateEndpointPropertyModel),
        typeof(ServerModel),
        typeof(ServerListResultModel),
        typeof(ServerPrivateEndpointConnectionModel),
        typeof(ServerPrivateEndpointConnectionPropertiesModel),
        typeof(ServerPrivateLinkServiceConnectionStatePropertyModel),
        typeof(ServerPropertiesModel),
        typeof(SkuModel),
        typeof(StorageProfileModel),
    };
}
