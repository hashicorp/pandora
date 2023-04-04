using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.Services;

internal class Definition : ResourceDefinition
{
    public string Name => "Services";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdminKeyKindConstant),
        typeof(HostingModeConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(ResourceTypeConstant),
        typeof(SearchServiceStatusConstant),
        typeof(SharedPrivateLinkResourceProvisioningStateConstant),
        typeof(SharedPrivateLinkResourceStatusConstant),
        typeof(SkuNameConstant),
        typeof(UnavailableNameReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityInputModel),
        typeof(CheckNameAvailabilityOutputModel),
        typeof(IPRuleModel),
        typeof(NetworkRuleSetModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointConnectionPropertiesPrivateEndpointModel),
        typeof(PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionStateModel),
        typeof(SearchServiceModel),
        typeof(SearchServicePropertiesModel),
        typeof(SearchServiceUpdateModel),
        typeof(SharedPrivateLinkResourceModel),
        typeof(SharedPrivateLinkResourcePropertiesModel),
        typeof(SkuModel),
    };
}
