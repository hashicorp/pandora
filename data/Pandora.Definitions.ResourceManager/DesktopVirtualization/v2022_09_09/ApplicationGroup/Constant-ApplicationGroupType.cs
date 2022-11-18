using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.ApplicationGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGroupTypeConstant
{
    [Description("Desktop")]
    Desktop,

    [Description("RemoteApp")]
    RemoteApp,
}
