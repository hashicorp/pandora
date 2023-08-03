// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementSubscriptionStateConstant
{
    [Description("Pending")]
    @pending,

    [Description("Active")]
    @active,

    [Description("Warning")]
    @warning,

    [Description("Disabled")]
    @disabled,

    [Description("Deleted")]
    @deleted,

    [Description("Blocked")]
    @blocked,

    [Description("LockedOut")]
    @lockedOut,
}
