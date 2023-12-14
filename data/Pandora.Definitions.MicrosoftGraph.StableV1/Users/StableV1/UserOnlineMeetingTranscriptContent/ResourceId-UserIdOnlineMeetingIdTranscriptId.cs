// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOnlineMeetingTranscriptContent;

internal class UserIdOnlineMeetingIdTranscriptId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/onlineMeetings/{onlineMeetingId}/transcripts/{callTranscriptId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOnlineMeetings", "onlineMeetings"),
        ResourceIDSegment.UserSpecified("onlineMeetingId"),
        ResourceIDSegment.Static("staticTranscripts", "transcripts"),
        ResourceIDSegment.UserSpecified("callTranscriptId")
    };
}
