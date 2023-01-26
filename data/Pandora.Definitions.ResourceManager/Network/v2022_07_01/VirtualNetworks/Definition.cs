using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworks;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ResourceNavigationLinksListOperation(),
        new ServiceAssociationLinksListOperation(),
        new SubnetsPrepareNetworkPoliciesOperation(),
        new SubnetsUnprepareNetworkPoliciesOperation(),
        new UpdateTagsOperation(),
        new VirtualNetworksCheckIPAddressAvailabilityOperation(),
        new VirtualNetworksListDdosProtectionStatusOperation(),
        new VirtualNetworksListUsageOperation(),
    };
}
