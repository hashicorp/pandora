// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.IPAllocations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPAllocationTypeConstant
{
    [Description("Hypernet")]
    Hypernet,

    [Description("Undefined")]
    Undefined,
}
