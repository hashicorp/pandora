// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrinterCapabilitiesMultipageLayoutsConstant
{
    [Description("ClockwiseFromTopLeft")]
    @clockwiseFromTopLeft,

    [Description("CounterclockwiseFromTopLeft")]
    @counterclockwiseFromTopLeft,

    [Description("CounterclockwiseFromTopRight")]
    @counterclockwiseFromTopRight,

    [Description("ClockwiseFromTopRight")]
    @clockwiseFromTopRight,

    [Description("CounterclockwiseFromBottomLeft")]
    @counterclockwiseFromBottomLeft,

    [Description("ClockwiseFromBottomLeft")]
    @clockwiseFromBottomLeft,

    [Description("CounterclockwiseFromBottomRight")]
    @counterclockwiseFromBottomRight,

    [Description("ClockwiseFromBottomRight")]
    @clockwiseFromBottomRight,
}
