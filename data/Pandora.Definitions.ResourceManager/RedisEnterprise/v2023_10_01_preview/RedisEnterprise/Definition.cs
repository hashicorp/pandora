using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.RedisEnterprise;

internal class Definition : ResourceDefinition
{
    public string Name => "RedisEnterprise";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOperation(),
        new DatabasesCreateOperation(),
        new DatabasesDeleteOperation(),
        new DatabasesExportOperation(),
        new DatabasesFlushOperation(),
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
        typeof(CmkIdentityTypeConstant),
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
        typeof(CheckNameAvailabilityParametersModel),
        typeof(ClusterModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterPropertiesEncryptionModel),
        typeof(ClusterPropertiesEncryptionCustomerManagedKeyEncryptionModel),
        typeof(ClusterPropertiesEncryptionCustomerManagedKeyEncryptionKeyEncryptionKeyIdentityModel),
        typeof(ClusterUpdateModel),
        typeof(DatabaseModel),
        typeof(DatabasePropertiesModel),
        typeof(DatabasePropertiesGeoReplicationModel),
        typeof(DatabaseUpdateModel),
        typeof(ExportClusterParametersModel),
        typeof(FlushParametersModel),
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
