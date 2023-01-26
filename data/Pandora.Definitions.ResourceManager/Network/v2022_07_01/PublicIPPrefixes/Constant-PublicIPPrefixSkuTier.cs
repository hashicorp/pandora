using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PublicIPPrefixes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicIPPrefixSkuTierConstant
{
    [Description("Global")]
    Global,

    [Description("Regional")]
    Regional,
}
