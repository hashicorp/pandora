using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.HostPool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostPoolTypeConstant
{
    [Description("BYODesktop")]
    BYODesktop,

    [Description("Personal")]
    Personal,

    [Description("Pooled")]
    Pooled,
}
