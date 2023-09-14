using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.Redis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TlsVersionConstant
{
    [Description("1.1")]
    OnePointOne,

    [Description("1.2")]
    OnePointTwo,

    [Description("1.0")]
    OnePointZero,
}
