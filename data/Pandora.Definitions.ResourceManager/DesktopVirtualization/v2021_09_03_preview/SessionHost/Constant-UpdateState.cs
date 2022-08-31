using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.SessionHost;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Initial")]
    Initial,

    [Description("Pending")]
    Pending,

    [Description("Started")]
    Started,

    [Description("Succeeded")]
    Succeeded,
}
