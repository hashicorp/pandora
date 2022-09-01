using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;

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
