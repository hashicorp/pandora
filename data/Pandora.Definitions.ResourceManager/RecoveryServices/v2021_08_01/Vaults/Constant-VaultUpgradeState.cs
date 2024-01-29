// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2021_08_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VaultUpgradeStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Unknown")]
    Unknown,

    [Description("Upgraded")]
    Upgraded,
}
