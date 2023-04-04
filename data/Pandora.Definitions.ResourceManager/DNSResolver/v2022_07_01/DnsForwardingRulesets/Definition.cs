using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNSResolver.v2022_07_01.DnsForwardingRulesets;

internal class Definition : ResourceDefinition
{
    public string Name => "DnsForwardingRulesets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListByVirtualNetworkOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DnsForwardingRulesetModel),
        typeof(DnsForwardingRulesetPatchModel),
        typeof(DnsForwardingRulesetPropertiesModel),
        typeof(SubResourceModel),
        typeof(VirtualNetworkDnsForwardingRulesetModel),
        typeof(VirtualNetworkLinkSubResourcePropertiesModel),
    };
}
