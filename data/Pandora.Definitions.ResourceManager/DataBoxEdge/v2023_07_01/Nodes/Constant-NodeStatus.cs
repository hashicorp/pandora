// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.Nodes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NodeStatusConstant
{
    [Description("Down")]
    Down,

    [Description("Rebooting")]
    Rebooting,

    [Description("ShuttingDown")]
    ShuttingDown,

    [Description("Unknown")]
    Unknown,

    [Description("Up")]
    Up,
}
