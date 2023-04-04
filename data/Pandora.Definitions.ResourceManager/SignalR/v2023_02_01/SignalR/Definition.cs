using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SignalR.v2023_02_01.SignalR;

internal class Definition : ResourceDefinition
{
    public string Name => "SignalR";
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
        typeof(FeatureFlagsConstant),
        typeof(KeyTypeConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(ScaleTypeConstant),
        typeof(ServiceKindConstant),
        typeof(SharedPrivateLinkResourceStatusConstant),
        typeof(SignalRRequestTypeConstant),
        typeof(SignalRSkuTierConstant),
        typeof(UpstreamAuthTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CustomCertificateModel),
        typeof(CustomCertificatePropertiesModel),
        typeof(CustomDomainModel),
        typeof(CustomDomainPropertiesModel),
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
        typeof(ServerlessSettingsModel),
        typeof(ServerlessUpstreamSettingsModel),
        typeof(ShareablePrivateLinkResourcePropertiesModel),
        typeof(ShareablePrivateLinkResourceTypeModel),
        typeof(SharedPrivateLinkResourceModel),
        typeof(SharedPrivateLinkResourcePropertiesModel),
        typeof(SignalRCorsSettingsModel),
        typeof(SignalRFeatureModel),
        typeof(SignalRKeysModel),
        typeof(SignalRNetworkACLsModel),
        typeof(SignalRPropertiesModel),
        typeof(SignalRResourceModel),
        typeof(SignalRTlsSettingsModel),
        typeof(SignalRUsageModel),
        typeof(SignalRUsageNameModel),
        typeof(SkuModel),
        typeof(SkuCapacityModel),
        typeof(SkuListModel),
        typeof(UpstreamAuthSettingsModel),
        typeof(UpstreamTemplateModel),
    };
}
