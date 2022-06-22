using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.HostPool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PreferredAppGroupTypeConstant
{
    [Description("Desktop")]
    Desktop,

    [Description("None")]
    None,

    [Description("RailApplications")]
    RailApplications,
}
