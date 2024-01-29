// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_06_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecureScoreLevelConstant
{
    [Description("Adequate")]
    Adequate,

    [Description("Maximum")]
    Maximum,

    [Description("Minimum")]
    Minimum,

    [Description("None")]
    None,
}
