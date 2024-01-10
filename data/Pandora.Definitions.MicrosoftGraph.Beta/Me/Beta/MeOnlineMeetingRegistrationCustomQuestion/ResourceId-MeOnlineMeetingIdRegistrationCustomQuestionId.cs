// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingRegistrationCustomQuestion;

internal class MeOnlineMeetingIdRegistrationCustomQuestionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/onlineMeetings/{onlineMeetingId}/registration/customQuestions/{meetingRegistrationQuestionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticOnlineMeetings", "onlineMeetings"),
        ResourceIDSegment.UserSpecified("onlineMeetingId"),
        ResourceIDSegment.Static("staticRegistration", "registration"),
        ResourceIDSegment.Static("staticCustomQuestions", "customQuestions"),
        ResourceIDSegment.UserSpecified("meetingRegistrationQuestionId")
    };
}
