// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserChatInstalledAppTeamsApp;

internal class UserIdChatIdInstalledAppId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/chats/{chatId}/installedApps/{teamsAppInstallationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticChats", "chats"),
        ResourceIDSegment.UserSpecified("chatId"),
        ResourceIDSegment.Static("staticInstalledApps", "installedApps"),
        ResourceIDSegment.UserSpecified("teamsAppInstallationId")
    };
}
