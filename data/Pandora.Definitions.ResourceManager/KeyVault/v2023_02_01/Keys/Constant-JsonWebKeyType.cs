// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.Keys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonWebKeyTypeConstant
{
    [Description("EC")]
    EC,

    [Description("EC-HSM")]
    ECNegativeHSM,

    [Description("RSA")]
    RSA,

    [Description("RSA-HSM")]
    RSANegativeHSM,
}
