using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserRoleConstant
{
    [Description("Admin")]
    Admin,

    [Description("None")]
    None,

    [Description("User")]
    User,
}
