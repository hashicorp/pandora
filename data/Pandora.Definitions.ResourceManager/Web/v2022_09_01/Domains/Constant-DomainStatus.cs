// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DomainStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Awaiting")]
    Awaiting,

    [Description("Cancelled")]
    Cancelled,

    [Description("Confiscated")]
    Confiscated,

    [Description("Disabled")]
    Disabled,

    [Description("Excluded")]
    Excluded,

    [Description("Expired")]
    Expired,

    [Description("Failed")]
    Failed,

    [Description("Held")]
    Held,

    [Description("JsonConverterFailed")]
    JsonConverterFailed,

    [Description("Locked")]
    Locked,

    [Description("Parked")]
    Parked,

    [Description("Pending")]
    Pending,

    [Description("Reserved")]
    Reserved,

    [Description("Reverted")]
    Reverted,

    [Description("Suspended")]
    Suspended,

    [Description("Transferred")]
    Transferred,

    [Description("Unknown")]
    Unknown,

    [Description("Unlocked")]
    Unlocked,

    [Description("Unparked")]
    Unparked,

    [Description("Updated")]
    Updated,
}
