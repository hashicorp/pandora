using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.LoadBalancers;

internal class Definition : ResourceDefinition
{
    public string Name => "LoadBalancers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new InboundNatRulesCreateOrUpdateOperation(),
        new InboundNatRulesDeleteOperation(),
        new InboundNatRulesGetOperation(),
        new InboundNatRulesListOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListInboundNatRulePortMappingsOperation(),
        new LoadBalancerBackendAddressPoolsCreateOrUpdateOperation(),
        new LoadBalancerBackendAddressPoolsDeleteOperation(),
        new LoadBalancerBackendAddressPoolsGetOperation(),
        new LoadBalancerBackendAddressPoolsListOperation(),
        new LoadBalancerFrontendIPConfigurationsGetOperation(),
        new LoadBalancerFrontendIPConfigurationsListOperation(),
        new LoadBalancerLoadBalancingRulesGetOperation(),
        new LoadBalancerLoadBalancingRulesListOperation(),
        new LoadBalancerNetworkInterfacesListOperation(),
        new LoadBalancerOutboundRulesGetOperation(),
        new LoadBalancerOutboundRulesListOperation(),
        new LoadBalancerProbesGetOperation(),
        new LoadBalancerProbesListOperation(),
        new SwapPublicIPAddressesOperation(),
        new UpdateTagsOperation(),
    };
}
