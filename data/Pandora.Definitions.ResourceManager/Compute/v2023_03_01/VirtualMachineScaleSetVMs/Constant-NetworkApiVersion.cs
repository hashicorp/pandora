// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineScaleSetVMs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkApiVersionConstant
{
    [Description("2020-11-01")]
    TwoZeroTwoZeroNegativeOneOneNegativeZeroOne,
}
