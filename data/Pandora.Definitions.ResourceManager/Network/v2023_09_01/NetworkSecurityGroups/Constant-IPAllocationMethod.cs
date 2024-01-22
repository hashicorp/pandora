// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkSecurityGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPAllocationMethodConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
