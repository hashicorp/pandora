// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.RedisEnterprise;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RdbFrequencyConstant
{
    [Description("12h")]
    OneTwoh,

    [Description("1h")]
    Oneh,

    [Description("6h")]
    Sixh,
}
