using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.HostPool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegistrationTokenOperationConstant
{
    [Description("Delete")]
    Delete,

    [Description("None")]
    None,

    [Description("Update")]
    Update,
}
