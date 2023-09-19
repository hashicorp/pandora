using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Namespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Namespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAuthorizationRuleOperation(),
        new DeleteOperation(),
        new DeleteAuthorizationRuleOperation(),
        new GetOperation(),
        new GetAuthorizationRuleOperation(),
        new GetPnsCredentialsOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListAuthorizationRulesOperation(),
        new ListKeysOperation(),
        new RegenerateKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
        typeof(NamespaceStatusConstant),
        typeof(NamespaceTypeConstant),
        typeof(OperationProvisioningStateConstant),
        typeof(PolicyKeyTypeConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateLinkConnectionStatusConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(ReplicationRegionConstant),
        typeof(SkuNameConstant),
        typeof(ZoneRedundancyPreferenceConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdmCredentialModel),
        typeof(AdmCredentialPropertiesModel),
        typeof(ApnsCredentialModel),
        typeof(ApnsCredentialPropertiesModel),
        typeof(BaiduCredentialModel),
        typeof(BaiduCredentialPropertiesModel),
        typeof(BrowserCredentialModel),
        typeof(BrowserCredentialPropertiesModel),
        typeof(CheckAvailabilityParametersModel),
        typeof(CheckAvailabilityResultModel),
        typeof(GcmCredentialModel),
        typeof(GcmCredentialPropertiesModel),
        typeof(IPRuleModel),
        typeof(MpnsCredentialModel),
        typeof(MpnsCredentialPropertiesModel),
        typeof(NamespacePatchParametersModel),
        typeof(NamespacePropertiesModel),
        typeof(NamespaceResourceModel),
        typeof(NetworkAclsModel),
        typeof(PnsCredentialsModel),
        typeof(PnsCredentialsResourceModel),
        typeof(PolicyKeyResourceModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointConnectionResourceModel),
        typeof(PublicInternetAuthorizationRuleModel),
        typeof(RemotePrivateEndpointConnectionModel),
        typeof(RemotePrivateLinkServiceConnectionStateModel),
        typeof(ResourceListKeysModel),
        typeof(SharedAccessAuthorizationRulePropertiesModel),
        typeof(SharedAccessAuthorizationRuleResourceModel),
        typeof(SkuModel),
        typeof(WnsCredentialModel),
        typeof(WnsCredentialPropertiesModel),
        typeof(XiaomiCredentialModel),
        typeof(XiaomiCredentialPropertiesModel),
    };
}
