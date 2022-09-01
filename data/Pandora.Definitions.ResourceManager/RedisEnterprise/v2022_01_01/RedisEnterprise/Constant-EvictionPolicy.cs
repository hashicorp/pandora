using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;

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
