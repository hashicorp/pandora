using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PartnerNamespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "PartnerNamespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListSharedAccessKeysOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IPActionTypeConstant),
        typeof(PartnerNamespaceProvisioningStateConstant),
        typeof(PartnerTopicRoutingModeConstant),
        typeof(PersistedConnectionStatusConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(ResourceProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionStateModel),
        typeof(InboundIPRuleModel),
        typeof(PartnerNamespaceModel),
        typeof(PartnerNamespacePropertiesModel),
        typeof(PartnerNamespaceRegenerateKeyRequestModel),
        typeof(PartnerNamespaceSharedAccessKeysModel),
        typeof(PartnerNamespaceUpdateParameterPropertiesModel),
        typeof(PartnerNamespaceUpdateParametersModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
    };
}
