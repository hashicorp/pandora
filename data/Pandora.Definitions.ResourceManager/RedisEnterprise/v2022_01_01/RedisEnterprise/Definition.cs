using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;

internal class Definition : ResourceDefinition
{
    public string Name => "RedisEnterprise";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DatabasesCreateOperation(),
        new DatabasesDeleteOperation(),
        new DatabasesExportOperation(),
        new DatabasesForceUnlinkOperation(),
        new DatabasesGetOperation(),
        new DatabasesImportOperation(),
        new DatabasesListByClusterOperation(),
        new DatabasesListKeysOperation(),
        new DatabasesRegenerateKeyOperation(),
        new DatabasesUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessKeyTypeConstant),
        typeof(AofFrequencyConstant),
        typeof(ClusteringPolicyConstant),
        typeof(EvictionPolicyConstant),
        typeof(LinkStateConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProtocolConstant),
        typeof(ProvisioningStateConstant),
        typeof(RdbFrequencyConstant),
        typeof(ResourceStateConstant),
        typeof(SkuNameConstant),
        typeof(TlsVersionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeysModel),
        typeof(ClusterModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterUpdateModel),
        typeof(DatabaseModel),
        typeof(DatabasePropertiesModel),
        typeof(DatabasePropertiesGeoReplicationModel),
        typeof(DatabaseUpdateModel),
        typeof(ExportClusterParametersModel),
        typeof(ForceUnlinkParametersModel),
        typeof(ImportClusterParametersModel),
        typeof(LinkedDatabaseModel),
        typeof(ModuleModel),
        typeof(PersistenceModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(RegenerateKeyParametersModel),
        typeof(SkuModel),
    };
}
