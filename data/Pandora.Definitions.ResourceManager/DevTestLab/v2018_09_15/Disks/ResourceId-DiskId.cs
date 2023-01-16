using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Disks;

internal class DiskId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/disks/{name}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDevTestLab", "Microsoft.DevTestLab"),
        ResourceIDSegment.Static("staticLabs", "labs"),
        ResourceIDSegment.UserSpecified("labName"),
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userName"),
        ResourceIDSegment.Static("staticDisks", "disks"),
        ResourceIDSegment.UserSpecified("name"),
    };
}
