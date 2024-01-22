// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OfficeTrafficCategoryConstant
{
    [Description("All")]
    All,

    [Description("None")]
    None,

    [Description("Optimize")]
    Optimize,

    [Description("OptimizeAndAllow")]
    OptimizeAndAllow,
}
