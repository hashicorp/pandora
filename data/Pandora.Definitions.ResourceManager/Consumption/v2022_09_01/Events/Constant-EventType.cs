// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2022_09_01.Events;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventTypeConstant
{
    [Description("CreditExpired")]
    CreditExpired,

    [Description("NewCredit")]
    NewCredit,

    [Description("PendingAdjustments")]
    PendingAdjustments,

    [Description("PendingCharges")]
    PendingCharges,

    [Description("PendingExpiredCredit")]
    PendingExpiredCredit,

    [Description("PendingNewCredit")]
    PendingNewCredit,

    [Description("SettledCharges")]
    SettledCharges,

    [Description("UnKnown")]
    UnKnown,
}
