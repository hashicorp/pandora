using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.FqdnListLocalRulestack;

internal class LocalRulestackFqdnListId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/{localRulestackName}/fqdnLists/{fqdnListName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticPaloAltoNetworksCloudngfw", "PaloAltoNetworks.Cloudngfw"),
        ResourceIDSegment.Static("staticLocalRulestacks", "localRulestacks"),
        ResourceIDSegment.UserSpecified("localRulestackName"),
        ResourceIDSegment.Static("staticFqdnLists", "fqdnLists"),
        ResourceIDSegment.UserSpecified("fqdnListName"),
    };
}
