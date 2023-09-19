// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeetingRecordingContent;

internal class UserIdOnlineMeetingIdRecordingId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/onlineMeetings/{onlineMeetingId}/recordings/{callRecordingId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOnlineMeetings", "onlineMeetings"),
        ResourceIDSegment.UserSpecified("onlineMeetingId"),
        ResourceIDSegment.Static("staticRecordings", "recordings"),
        ResourceIDSegment.UserSpecified("callRecordingId")
    };
}
