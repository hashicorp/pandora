// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChannelMappingConstant
{
    [Description("BackLeft")]
    BackLeft,

    [Description("BackRight")]
    BackRight,

    [Description("Center")]
    Center,

    [Description("FrontLeft")]
    FrontLeft,

    [Description("FrontRight")]
    FrontRight,

    [Description("LowFrequencyEffects")]
    LowFrequencyEffects,

    [Description("StereoLeft")]
    StereoLeft,

    [Description("StereoRight")]
    StereoRight,
}
