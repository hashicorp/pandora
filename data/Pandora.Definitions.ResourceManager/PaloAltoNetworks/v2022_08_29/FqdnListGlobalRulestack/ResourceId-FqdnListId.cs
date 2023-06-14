using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.FqdnListGlobalRulestack;

internal class FqdnListId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/PaloAltoNetworks.CloudNGFW/globalRuleStacks/{globalRuleStackName}/fqdnLists/{fqdnListName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticPaloAltoNetworksCloudNGFW", "PaloAltoNetworks.CloudNGFW"),
        ResourceIDSegment.Static("staticGlobalRuleStacks", "globalRuleStacks"),
        ResourceIDSegment.UserSpecified("globalRuleStackName"),
        ResourceIDSegment.Static("staticFqdnLists", "fqdnLists"),
        ResourceIDSegment.UserSpecified("fqdnListName"),
    };
}
