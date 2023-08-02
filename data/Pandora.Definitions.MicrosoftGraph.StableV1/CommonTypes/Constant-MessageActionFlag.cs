// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MessageActionFlagConstant
{
    [Description("Any")]
    @any,

    [Description("Call")]
    @call,

    [Description("DoNotForward")]
    @doNotForward,

    [Description("FollowUp")]
    @followUp,

    [Description("Fyi")]
    @fyi,

    [Description("Forward")]
    @forward,

    [Description("NoResponseNecessary")]
    @noResponseNecessary,

    [Description("Read")]
    @read,

    [Description("Reply")]
    @reply,

    [Description("ReplyToAll")]
    @replyToAll,

    [Description("Review")]
    @review,
}
