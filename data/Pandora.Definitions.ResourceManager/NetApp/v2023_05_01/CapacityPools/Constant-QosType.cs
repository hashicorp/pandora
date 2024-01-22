// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_05_01.CapacityPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QosTypeConstant
{
    [Description("Auto")]
    Auto,

    [Description("Manual")]
    Manual,
}
