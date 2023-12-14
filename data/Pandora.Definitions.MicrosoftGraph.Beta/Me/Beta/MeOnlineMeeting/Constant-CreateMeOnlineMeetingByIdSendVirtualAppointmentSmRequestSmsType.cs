// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeeting;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateMeOnlineMeetingByIdSendVirtualAppointmentSmRequestSmsTypeConstant
{
    [Description("Confirmation")]
    @confirmation,

    [Description("Reschedule")]
    @reschedule,

    [Description("Cancellation")]
    @cancellation,
}
