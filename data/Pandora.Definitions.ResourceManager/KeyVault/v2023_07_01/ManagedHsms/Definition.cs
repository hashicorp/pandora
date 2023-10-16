using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_07_01.ManagedHsms;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedHsms";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckMhsmNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDeletedOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListDeletedOperation(),
        new PurgeDeletedOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionsRequiredConstant),
        typeof(ActivationStatusConstant),
        typeof(CreateModeConstant),
        typeof(GeoReplicationRegionProvisioningStateConstant),
        typeof(ManagedHsmSkuFamilyConstant),
        typeof(ManagedHsmSkuNameConstant),
        typeof(NetworkRuleActionConstant),
        typeof(NetworkRuleBypassOptionsConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(ReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckMhsmNameAvailabilityParametersModel),
        typeof(CheckMhsmNameAvailabilityResultModel),
        typeof(DeletedManagedHsmModel),
        typeof(DeletedManagedHsmPropertiesModel),
        typeof(MHSMGeoReplicatedRegionModel),
        typeof(MHSMIPRuleModel),
        typeof(MHSMNetworkRuleSetModel),
        typeof(MHSMPrivateEndpointModel),
        typeof(MHSMPrivateEndpointConnectionItemModel),
        typeof(MHSMPrivateEndpointConnectionPropertiesModel),
        typeof(MHSMPrivateLinkServiceConnectionStateModel),
        typeof(MHSMVirtualNetworkRuleModel),
        typeof(ManagedHSMSecurityDomainPropertiesModel),
        typeof(ManagedHsmModel),
        typeof(ManagedHsmPropertiesModel),
        typeof(ManagedHsmSkuModel),
    };
}
