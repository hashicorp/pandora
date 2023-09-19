// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventMessageResponseMeetingMessageTypeConstant
{
    [Description("None")]
    @none,

    [Description("MeetingRequest")]
    @meetingRequest,

    [Description("MeetingCancelled")]
    @meetingCancelled,

    [Description("MeetingAccepted")]
    @meetingAccepted,

    [Description("MeetingTenativelyAccepted")]
    @meetingTenativelyAccepted,

    [Description("MeetingDeclined")]
    @meetingDeclined,
}
