using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.HostPool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoadBalancerTypeConstant
{
    [Description("BreadthFirst")]
    BreadthFirst,

    [Description("DepthFirst")]
    DepthFirst,

    [Description("Persistent")]
    Persistent,
}
