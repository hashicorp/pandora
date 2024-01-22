// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.ManagedHsmKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonWebKeyCurveNameConstant
{
    [Description("P-521")]
    PNegativeFiveTwoOne,

    [Description("P-384")]
    PNegativeThreeEightFour,

    [Description("P-256")]
    PNegativeTwoFiveSix,

    [Description("P-256K")]
    PNegativeTwoFiveSixK,
}
