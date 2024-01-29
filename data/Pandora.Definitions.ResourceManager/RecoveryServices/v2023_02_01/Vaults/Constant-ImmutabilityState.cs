// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_02_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImmutabilityStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Locked")]
    Locked,

    [Description("Unlocked")]
    Unlocked,
}
