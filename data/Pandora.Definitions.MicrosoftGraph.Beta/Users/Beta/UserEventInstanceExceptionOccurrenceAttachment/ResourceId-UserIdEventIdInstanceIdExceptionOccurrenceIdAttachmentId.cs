// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserEventInstanceExceptionOccurrenceAttachment;

internal class UserIdEventIdInstanceIdExceptionOccurrenceIdAttachmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/events/{eventId}/instances/{eventId1}/exceptionOccurrences/{eventId2}/attachments/{attachmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticEvents", "events"),
        ResourceIDSegment.UserSpecified("eventId"),
        ResourceIDSegment.Static("staticInstances", "instances"),
        ResourceIDSegment.UserSpecified("eventId1"),
        ResourceIDSegment.Static("staticExceptionOccurrences", "exceptionOccurrences"),
        ResourceIDSegment.UserSpecified("eventId2"),
        ResourceIDSegment.Static("staticAttachments", "attachments"),
        ResourceIDSegment.UserSpecified("attachmentId")
    };
}
