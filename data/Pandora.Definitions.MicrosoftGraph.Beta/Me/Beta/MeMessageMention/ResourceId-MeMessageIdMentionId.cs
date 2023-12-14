// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMessageMention;

internal class MeMessageIdMentionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/messages/{messageId}/mentions/{mentionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticMessages", "messages"),
        ResourceIDSegment.UserSpecified("messageId"),
        ResourceIDSegment.Static("staticMentions", "mentions"),
        ResourceIDSegment.UserSpecified("mentionId")
    };
}
