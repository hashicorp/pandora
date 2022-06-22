using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.ScalingPlan;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StopHostsWhenConstant
{
    [Description("ZeroActiveSessions")]
    ZeroActiveSessions,

    [Description("ZeroSessions")]
    ZeroSessions,
}
