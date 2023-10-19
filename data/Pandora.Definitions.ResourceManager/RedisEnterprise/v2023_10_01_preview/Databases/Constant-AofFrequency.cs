using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AofFrequencyConstant
{
    [Description("always")]
    Always,

    [Description("1s")]
    Ones,
}
