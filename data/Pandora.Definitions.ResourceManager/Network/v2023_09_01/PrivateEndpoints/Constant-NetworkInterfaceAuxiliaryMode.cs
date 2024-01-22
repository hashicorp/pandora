// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.PrivateEndpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkInterfaceAuxiliaryModeConstant
{
    [Description("AcceleratedConnections")]
    AcceleratedConnections,

    [Description("Floating")]
    Floating,

    [Description("MaxConnections")]
    MaxConnections,

    [Description("None")]
    None,
}
