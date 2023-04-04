using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_11_01.Namespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Namespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateNetworkRuleSetOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetNetworkRuleSetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListNetworkRuleSetsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DefaultActionConstant),
        typeof(EndPointProvisioningStateConstant),
        typeof(KeySourceConstant),
        typeof(NetworkRuleIPActionConstant),
        typeof(PrivateLinkConnectionStatusConstant),
        typeof(PublicNetworkAccessFlagConstant),
        typeof(SkuNameConstant),
        typeof(SkuTierConstant),
        typeof(UnavailableReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityModel),
        typeof(CheckNameAvailabilityResultModel),
        typeof(ConnectionStateModel),
        typeof(EncryptionModel),
        typeof(KeyVaultPropertiesModel),
        typeof(NWRuleSetIPRulesModel),
        typeof(NWRuleSetVirtualNetworkRulesModel),
        typeof(NetworkRuleSetModel),
        typeof(NetworkRuleSetPropertiesModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(SBNamespaceModel),
        typeof(SBNamespacePropertiesModel),
        typeof(SBNamespaceUpdateParametersModel),
        typeof(SBNamespaceUpdatePropertiesModel),
        typeof(SBSkuModel),
        typeof(SubnetModel),
        typeof(UserAssignedIdentityPropertiesModel),
    };
}
