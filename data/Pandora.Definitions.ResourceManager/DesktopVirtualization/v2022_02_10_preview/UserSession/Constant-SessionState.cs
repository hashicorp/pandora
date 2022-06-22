using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.UserSession;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SessionStateConstant
{
    [Description("Active")]
    Active,

    [Description("Disconnected")]
    Disconnected,

    [Description("LogOff")]
    LogOff,

    [Description("Pending")]
    Pending,

    [Description("Unknown")]
    Unknown,

    [Description("UserProfileDiskMounted")]
    UserProfileDiskMounted,
}
