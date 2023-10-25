using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrincipalTypeConstant
{
    [Description("Application")]
    Application,

    [Description("Group")]
    Group,

    [Description("User")]
    User,
}
