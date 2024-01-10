// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeChatPinnedMessageMessage;

internal class MeChatIdPinnedMessageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/chats/{chatId}/pinnedMessages/{pinnedChatMessageInfoId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticChats", "chats"),
        ResourceIDSegment.UserSpecified("chatId"),
        ResourceIDSegment.Static("staticPinnedMessages", "pinnedMessages"),
        ResourceIDSegment.UserSpecified("pinnedChatMessageInfoId")
    };
}
