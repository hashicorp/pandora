using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.UserSession;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationTypeConstant
{
    [Description("Desktop")]
    Desktop,

    [Description("RemoteApp")]
    RemoteApp,
}
