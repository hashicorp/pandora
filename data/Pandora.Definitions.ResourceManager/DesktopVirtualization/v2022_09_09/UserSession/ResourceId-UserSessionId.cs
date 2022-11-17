using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.UserSession;

internal class UserSessionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/sessionHosts/{sessionHostName}/userSessions/{userSessionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDesktopVirtualization", "Microsoft.DesktopVirtualization"),
        ResourceIDSegment.Static("staticHostPools", "hostPools"),
        ResourceIDSegment.UserSpecified("hostPoolName"),
        ResourceIDSegment.Static("staticSessionHosts", "sessionHosts"),
        ResourceIDSegment.UserSpecified("sessionHostName"),
        ResourceIDSegment.Static("staticUserSessions", "userSessions"),
        ResourceIDSegment.UserSpecified("userSessionId"),
    };
}
