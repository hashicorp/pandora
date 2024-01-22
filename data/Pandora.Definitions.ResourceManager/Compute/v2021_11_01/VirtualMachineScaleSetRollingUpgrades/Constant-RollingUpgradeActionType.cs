// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSetRollingUpgrades;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RollingUpgradeActionTypeConstant
{
    [Description("Cancel")]
    Cancel,

    [Description("Start")]
    Start,
}
