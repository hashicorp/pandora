using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Redis.v2022_06_01.Redis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuFamilyConstant
{
    [Description("C")]
    C,

    [Description("P")]
    P,
}
