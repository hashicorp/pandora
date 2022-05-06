using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.VirtualNetworkRules;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworkRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NamespacesCreateOrUpdateVirtualNetworkRuleOperation(),
        new NamespacesDeleteVirtualNetworkRuleOperation(),
        new NamespacesGetVirtualNetworkRuleOperation(),
        new NamespacesListVirtualNetworkRulesOperation(),
    };
}
