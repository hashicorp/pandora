// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VirtualMachineInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AllocationMethodConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
