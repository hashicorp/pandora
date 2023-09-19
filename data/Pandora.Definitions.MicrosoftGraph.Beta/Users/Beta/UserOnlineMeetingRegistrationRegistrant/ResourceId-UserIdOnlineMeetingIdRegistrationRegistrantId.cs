// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeetingRegistrationRegistrant;

internal class UserIdOnlineMeetingIdRegistrationRegistrantId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/onlineMeetings/{onlineMeetingId}/registration/registrants/{meetingRegistrantBaseId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticOnlineMeetings", "onlineMeetings"),
        ResourceIDSegment.UserSpecified("onlineMeetingId"),
        ResourceIDSegment.Static("staticRegistration", "registration"),
        ResourceIDSegment.Static("staticRegistrants", "registrants"),
        ResourceIDSegment.UserSpecified("meetingRegistrantBaseId")
    };
}
