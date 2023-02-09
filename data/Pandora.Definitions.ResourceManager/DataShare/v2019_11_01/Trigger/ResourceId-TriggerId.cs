using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.Trigger;

internal class TriggerId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions/{shareSubscriptionName}/triggers/{triggerName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDataShare", "Microsoft.DataShare"),
        ResourceIDSegment.Static("staticAccounts", "accounts"),
        ResourceIDSegment.UserSpecified("accountName"),
        ResourceIDSegment.Static("staticShareSubscriptions", "shareSubscriptions"),
        ResourceIDSegment.UserSpecified("shareSubscriptionName"),
        ResourceIDSegment.Static("staticTriggers", "triggers"),
        ResourceIDSegment.UserSpecified("triggerName"),
    };
}
