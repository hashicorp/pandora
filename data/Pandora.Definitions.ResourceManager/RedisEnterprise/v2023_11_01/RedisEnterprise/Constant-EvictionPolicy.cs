// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_11_01.RedisEnterprise;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EvictionPolicyConstant
{
    [Description("AllKeysLFU")]
    AllKeysLFU,

    [Description("AllKeysLRU")]
    AllKeysLRU,

    [Description("AllKeysRandom")]
    AllKeysRandom,

    [Description("NoEviction")]
    NoEviction,

    [Description("VolatileLFU")]
    VolatileLFU,

    [Description("VolatileLRU")]
    VolatileLRU,

    [Description("VolatileRandom")]
    VolatileRandom,

    [Description("VolatileTTL")]
    VolatileTTL,
}
