// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserNotification;

internal class UserIdNotificationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/notifications/{notificationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticNotifications", "notifications"),
        ResourceIDSegment.UserSpecified("notificationId")
    };
}
