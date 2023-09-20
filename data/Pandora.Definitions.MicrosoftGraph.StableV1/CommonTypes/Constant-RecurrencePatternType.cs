// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecurrencePatternTypeConstant
{
    [Description("Daily")]
    @daily,

    [Description("Weekly")]
    @weekly,

    [Description("AbsoluteMonthly")]
    @absoluteMonthly,

    [Description("RelativeMonthly")]
    @relativeMonthly,

    [Description("AbsoluteYearly")]
    @absoluteYearly,

    [Description("RelativeYearly")]
    @relativeYearly,
}
