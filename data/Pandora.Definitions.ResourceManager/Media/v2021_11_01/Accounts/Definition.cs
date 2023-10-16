using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Accounts;

internal class Definition : ResourceDefinition
{
    public string Name => "Accounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new LocationsCheckNameAvailabilityOperation(),
        new MediaservicesCreateOrUpdateOperation(),
        new MediaservicesDeleteOperation(),
        new MediaservicesGetOperation(),
        new MediaservicesListOperation(),
        new MediaservicesListBySubscriptionOperation(),
        new MediaservicesListEdgePoliciesOperation(),
        new MediaservicesSyncStorageKeysOperation(),
        new MediaservicesUpdateOperation(),
        new PrivateEndpointConnectionsCreateOrUpdateOperation(),
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateLinkResourcesGetOperation(),
        new PrivateLinkResourcesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccountEncryptionKeyTypeConstant),
        typeof(DefaultActionConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(StorageAccountTypeConstant),
        typeof(StorageAuthenticationConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessControlModel),
        typeof(AccountEncryptionModel),
        typeof(CheckNameAvailabilityInputModel),
        typeof(EdgePoliciesModel),
        typeof(EdgeUsageDataCollectionPolicyModel),
        typeof(EdgeUsageDataEventHubModel),
        typeof(EntityNameAvailabilityCheckOutputModel),
        typeof(KeyDeliveryModel),
        typeof(KeyVaultPropertiesModel),
        typeof(ListEdgePoliciesInputModel),
        typeof(MediaServiceModel),
        typeof(MediaServiceIdentityModel),
        typeof(MediaServicePropertiesModel),
        typeof(MediaServiceUpdateModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionListResultModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkResourceModel),
        typeof(PrivateLinkResourceListResultModel),
        typeof(PrivateLinkResourcePropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ResourceIdentityModel),
        typeof(StorageAccountModel),
        typeof(SyncStorageKeysInputModel),
        typeof(UserAssignedManagedIdentityModel),
    };
}
