using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.ScalingPlanPooledSchedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SessionHostLoadBalancingAlgorithmConstant
{
    [Description("BreadthFirst")]
    BreadthFirst,

    [Description("DepthFirst")]
    DepthFirst,
}
