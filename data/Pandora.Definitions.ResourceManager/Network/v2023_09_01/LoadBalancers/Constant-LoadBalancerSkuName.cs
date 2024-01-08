using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.LoadBalancers;

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
