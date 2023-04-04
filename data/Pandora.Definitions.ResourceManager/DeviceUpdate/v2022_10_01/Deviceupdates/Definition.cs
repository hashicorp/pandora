using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.Deviceupdates;

internal class Definition : ResourceDefinition
{
    public string Name => "Deviceupdates";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccountsCreateOperation(),
        new AccountsDeleteOperation(),
        new AccountsGetOperation(),
        new AccountsHeadOperation(),
        new AccountsListByResourceGroupOperation(),
        new AccountsListBySubscriptionOperation(),
        new AccountsUpdateOperation(),
        new CheckNameAvailabilityOperation(),
        new InstancesCreateOperation(),
        new InstancesDeleteOperation(),
        new InstancesGetOperation(),
        new InstancesHeadOperation(),
        new InstancesListByAccountOperation(),
        new InstancesUpdateOperation(),
        new PrivateEndpointConnectionProxiesUpdatePrivateEndpointPropertiesOperation(),
        new PrivateEndpointConnectionProxiesValidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthenticationTypeConstant),
        typeof(CheckNameAvailabilityReasonConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointConnectionProxyProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(RoleConstant),
        typeof(SKUConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccountModel),
        typeof(AccountPropertiesModel),
        typeof(AccountUpdateModel),
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(ConnectionDetailsModel),
        typeof(DiagnosticStoragePropertiesModel),
        typeof(GroupConnectivityInformationModel),
        typeof(InstanceModel),
        typeof(InstancePropertiesModel),
        typeof(IotHubSettingsModel),
        typeof(LocationModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointConnectionProxyModel),
        typeof(PrivateEndpointConnectionProxyPropertiesModel),
        typeof(PrivateEndpointUpdateModel),
        typeof(PrivateLinkServiceConnectionModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(PrivateLinkServiceProxyModel),
        typeof(RemotePrivateEndpointModel),
        typeof(RemotePrivateEndpointConnectionModel),
        typeof(TagUpdateModel),
    };
}
