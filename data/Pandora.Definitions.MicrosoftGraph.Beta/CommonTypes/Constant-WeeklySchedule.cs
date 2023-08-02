// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WeeklyScheduleConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("Everyday")]
    @everyday,

    [Description("Sunday")]
    @sunday,

    [Description("Monday")]
    @monday,

    [Description("Tuesday")]
    @tuesday,

    [Description("Wednesday")]
    @wednesday,

    [Description("Thursday")]
    @thursday,

    [Description("Friday")]
    @friday,

    [Description("Saturday")]
    @saturday,

    [Description("NoScheduledScan")]
    @noScheduledScan,
}
