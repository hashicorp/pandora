// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeOffItemThemeConstant
{
    [Description("White")]
    @white,

    [Description("Blue")]
    @blue,

    [Description("Green")]
    @green,

    [Description("Purple")]
    @purple,

    [Description("Pink")]
    @pink,

    [Description("Yellow")]
    @yellow,

    [Description("Gray")]
    @gray,

    [Description("DarkBlue")]
    @darkBlue,

    [Description("DarkGreen")]
    @darkGreen,

    [Description("DarkPurple")]
    @darkPurple,

    [Description("DarkPink")]
    @darkPink,

    [Description("DarkYellow")]
    @darkYellow,
}
