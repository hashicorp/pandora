// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserChatPermissionGrant;

internal class UserIdChatIdPermissionGrantId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/chats/{chatId}/permissionGrants/{resourceSpecificPermissionGrantId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticChats", "chats"),
        ResourceIDSegment.UserSpecified("chatId"),
        ResourceIDSegment.Static("staticPermissionGrants", "permissionGrants"),
        ResourceIDSegment.UserSpecified("resourceSpecificPermissionGrantId")
    };
}
