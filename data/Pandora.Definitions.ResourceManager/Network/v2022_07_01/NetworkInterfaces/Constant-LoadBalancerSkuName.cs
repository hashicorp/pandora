using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkInterfaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoadBalancerSkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("Gateway")]
    Gateway,

    [Description("Standard")]
    Standard,
}
