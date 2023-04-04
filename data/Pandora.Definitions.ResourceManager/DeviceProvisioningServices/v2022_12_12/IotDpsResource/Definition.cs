using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_12_12.IotDpsResource;

internal class Definition : ResourceDefinition
{
    public string Name => "IotDpsResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckProvisioningServiceNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdatePrivateEndpointConnectionOperation(),
        new DeleteOperation(),
        new DeletePrivateEndpointConnectionOperation(),
        new GetOperation(),
        new GetPrivateEndpointConnectionOperation(),
        new GetPrivateLinkResourcesOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new ListKeysForKeyNameOperation(),
        new ListPrivateEndpointConnectionsOperation(),
        new ListPrivateLinkResourcesOperation(),
        new ListValidSkusOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsDescriptionConstant),
        typeof(AllocationPolicyConstant),
        typeof(IPFilterActionTypeConstant),
        typeof(IPFilterTargetTypeConstant),
        typeof(IotDpsSkuConstant),
        typeof(NameUnavailabilityReasonConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(StateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GroupIdInformationModel),
        typeof(GroupIdInformationPropertiesModel),
        typeof(IPFilterRuleModel),
        typeof(IotDpsPropertiesDescriptionModel),
        typeof(IotDpsSkuDefinitionModel),
        typeof(IotDpsSkuInfoModel),
        typeof(IotHubDefinitionDescriptionModel),
        typeof(NameAvailabilityInfoModel),
        typeof(OperationInputsModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkResourcesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ProvisioningServiceDescriptionModel),
        typeof(SharedAccessSignatureAuthorizationRuleAccessRightsDescriptionModel),
        typeof(TagsResourceModel),
    };
}
