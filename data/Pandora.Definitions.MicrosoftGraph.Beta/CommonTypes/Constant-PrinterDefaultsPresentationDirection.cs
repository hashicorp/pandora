// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrinterDefaultsPresentationDirectionConstant
{
    [Description("ClockwiseFromTopLeft")]
    @clockwiseFromTopLeft,

    [Description("CounterClockwiseFromTopLeft")]
    @counterClockwiseFromTopLeft,

    [Description("CounterClockwiseFromTopRight")]
    @counterClockwiseFromTopRight,

    [Description("ClockwiseFromTopRight")]
    @clockwiseFromTopRight,

    [Description("CounterClockwiseFromBottomLeft")]
    @counterClockwiseFromBottomLeft,

    [Description("ClockwiseFromBottomLeft")]
    @clockwiseFromBottomLeft,

    [Description("CounterClockwiseFromBottomRight")]
    @counterClockwiseFromBottomRight,

    [Description("ClockwiseFromBottomRight")]
    @clockwiseFromBottomRight,
}
