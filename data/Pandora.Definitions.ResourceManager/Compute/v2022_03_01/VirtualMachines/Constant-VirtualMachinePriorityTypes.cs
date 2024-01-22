// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualMachinePriorityTypesConstant
{
    [Description("Low")]
    Low,

    [Description("Regular")]
    Regular,

    [Description("Spot")]
    Spot,
}
