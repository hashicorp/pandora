// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventMessageRequestMeetingRequestTypeConstant
{
    [Description("None")]
    @none,

    [Description("NewMeetingRequest")]
    @newMeetingRequest,

    [Description("FullUpdate")]
    @fullUpdate,

    [Description("InformationalUpdate")]
    @informationalUpdate,

    [Description("SilentUpdate")]
    @silentUpdate,

    [Description("Outdated")]
    @outdated,

    [Description("PrincipalWantsCopy")]
    @principalWantsCopy,
}
