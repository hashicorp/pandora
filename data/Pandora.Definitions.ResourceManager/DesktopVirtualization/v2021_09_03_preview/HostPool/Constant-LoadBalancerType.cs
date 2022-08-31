using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.HostPool;

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
