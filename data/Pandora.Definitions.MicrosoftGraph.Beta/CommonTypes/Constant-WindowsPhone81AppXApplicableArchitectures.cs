// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsPhone81AppXApplicableArchitecturesConstant
{
    [Description("None")]
    @none,

    [Description("X86")]
    @x86,

    [Description("X64")]
    @x64,

    [Description("Arm")]
    @arm,

    [Description("Neutral")]
    @neutral,

    [Description("Arm64")]
    @arm64,
}
