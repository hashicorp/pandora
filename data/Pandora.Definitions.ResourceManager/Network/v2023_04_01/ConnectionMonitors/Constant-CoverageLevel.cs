// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.ConnectionMonitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CoverageLevelConstant
{
    [Description("AboveAverage")]
    AboveAverage,

    [Description("Average")]
    Average,

    [Description("BelowAverage")]
    BelowAverage,

    [Description("Default")]
    Default,

    [Description("Full")]
    Full,

    [Description("Low")]
    Low,
}
