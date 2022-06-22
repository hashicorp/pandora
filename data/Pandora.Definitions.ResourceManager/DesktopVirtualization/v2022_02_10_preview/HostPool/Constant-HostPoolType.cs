using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.HostPool;

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
