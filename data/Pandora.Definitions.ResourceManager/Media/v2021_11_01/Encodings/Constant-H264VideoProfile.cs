// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum H264VideoProfileConstant
{
    [Description("Auto")]
    Auto,

    [Description("Baseline")]
    Baseline,

    [Description("High")]
    High,

    [Description("High444")]
    HighFourFourFour,

    [Description("High422")]
    HighFourTwoTwo,

    [Description("Main")]
    Main,
}
