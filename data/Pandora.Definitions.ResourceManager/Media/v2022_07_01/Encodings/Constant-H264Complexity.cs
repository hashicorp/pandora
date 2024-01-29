// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_07_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum H264ComplexityConstant
{
    [Description("Balanced")]
    Balanced,

    [Description("Quality")]
    Quality,

    [Description("Speed")]
    Speed,
}
