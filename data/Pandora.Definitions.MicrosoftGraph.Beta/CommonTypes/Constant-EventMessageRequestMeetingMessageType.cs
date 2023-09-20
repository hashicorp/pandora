// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventMessageRequestMeetingMessageTypeConstant
{
    [Description("None")]
    @none,

    [Description("MeetingRequest")]
    @meetingRequest,

    [Description("MeetingCancelled")]
    @meetingCancelled,

    [Description("MeetingAccepted")]
    @meetingAccepted,

    [Description("MeetingTentativelyAccepted")]
    @meetingTentativelyAccepted,

    [Description("MeetingDeclined")]
    @meetingDeclined,
}
