using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Purview.v2021_12_01.Account;

internal class Definition : ResourceDefinition
{
    public string Name => "Account";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddRootCollectionAdminOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccountProvisioningStateConstant),
        typeof(ManagedEventHubStateConstant),
        typeof(ManagedResourcesPublicNetworkAccessConstant),
        typeof(NameConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeysModel),
        typeof(AccountModel),
        typeof(AccountEndpointsModel),
        typeof(AccountPropertiesModel),
        typeof(AccountSkuModel),
        typeof(AccountStatusModel),
        typeof(AccountUpdateParametersModel),
        typeof(CloudConnectorsModel),
        typeof(CollectionAdminUpdateModel),
        typeof(ErrorModelModel),
        typeof(ManagedResourcesModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
    };
}
