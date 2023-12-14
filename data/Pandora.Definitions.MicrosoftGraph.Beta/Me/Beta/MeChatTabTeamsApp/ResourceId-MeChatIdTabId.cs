// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeChatTabTeamsApp;

internal class MeChatIdTabId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/chats/{chatId}/tabs/{teamsTabId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticChats", "chats"),
        ResourceIDSegment.UserSpecified("chatId"),
        ResourceIDSegment.Static("staticTabs", "tabs"),
        ResourceIDSegment.UserSpecified("teamsTabId")
    };
}
