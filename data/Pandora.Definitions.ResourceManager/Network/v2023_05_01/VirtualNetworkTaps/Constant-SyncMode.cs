// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.VirtualNetworkTaps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncModeConstant
{
    [Description("Automatic")]
    Automatic,

    [Description("Manual")]
    Manual,
}
