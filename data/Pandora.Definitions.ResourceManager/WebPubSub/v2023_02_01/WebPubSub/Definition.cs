using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.WebPubSub.v2023_02_01.WebPubSub;

internal class Definition : ResourceDefinition
{
    public string Name => "WebPubSub";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CustomCertificatesCreateOrUpdateOperation(),
        new CustomCertificatesDeleteOperation(),
        new CustomCertificatesGetOperation(),
        new CustomCertificatesListOperation(),
        new CustomDomainsCreateOrUpdateOperation(),
        new CustomDomainsDeleteOperation(),
        new CustomDomainsGetOperation(),
        new CustomDomainsListOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new HubsCreateOrUpdateOperation(),
        new HubsDeleteOperation(),
        new HubsGetOperation(),
        new HubsListOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new ListSkusOperation(),
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateEndpointConnectionsUpdateOperation(),
        new PrivateLinkResourcesListOperation(),
        new RegenerateKeyOperation(),
        new RestartOperation(),
        new SharedPrivateLinkResourcesCreateOrUpdateOperation(),
        new SharedPrivateLinkResourcesDeleteOperation(),
        new SharedPrivateLinkResourcesGetOperation(),
        new SharedPrivateLinkResourcesListOperation(),
        new UpdateOperation(),
        new UsagesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ACLActionConstant),
        typeof(EventListenerEndpointDiscriminatorConstant),
        typeof(EventListenerFilterDiscriminatorConstant),
        typeof(KeyTypeConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(ScaleTypeConstant),
        typeof(SharedPrivateLinkResourceStatusConstant),
        typeof(UpstreamAuthTypeConstant),
        typeof(WebPubSubRequestTypeConstant),
        typeof(WebPubSubSkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CustomCertificateModel),
        typeof(CustomCertificatePropertiesModel),
        typeof(CustomDomainModel),
        typeof(CustomDomainPropertiesModel),
        typeof(EventHandlerModel),
        typeof(EventHubEndpointModel),
        typeof(EventListenerModel),
        typeof(EventListenerEndpointModel),
        typeof(EventListenerFilterModel),
        typeof(EventNameFilterModel),
        typeof(LiveTraceCategoryModel),
        typeof(LiveTraceConfigurationModel),
        typeof(ManagedIdentitySettingsModel),
        typeof(NameAvailabilityModel),
        typeof(NameAvailabilityParametersModel),
        typeof(NetworkACLModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointACLModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkResourceModel),
        typeof(PrivateLinkResourcePropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(RegenerateKeyParametersModel),
        typeof(ResourceLogCategoryModel),
        typeof(ResourceLogConfigurationModel),
        typeof(ResourceReferenceModel),
        typeof(ResourceSkuModel),
        typeof(ShareablePrivateLinkResourcePropertiesModel),
        typeof(ShareablePrivateLinkResourceTypeModel),
        typeof(SharedPrivateLinkResourceModel),
        typeof(SharedPrivateLinkResourcePropertiesModel),
        typeof(SignalRServiceUsageModel),
        typeof(SignalRServiceUsageNameModel),
        typeof(SkuModel),
        typeof(SkuCapacityModel),
        typeof(SkuListModel),
        typeof(UpstreamAuthSettingsModel),
        typeof(WebPubSubHubModel),
        typeof(WebPubSubHubPropertiesModel),
        typeof(WebPubSubKeysModel),
        typeof(WebPubSubNetworkACLsModel),
        typeof(WebPubSubPropertiesModel),
        typeof(WebPubSubResourceModel),
        typeof(WebPubSubTlsSettingsModel),
    };
}
