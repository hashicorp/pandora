using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Administrators;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrincipalTypeConstant
{
    [Description("Group")]
    Group,

    [Description("ServicePrincipal")]
    ServicePrincipal,

    [Description("Unknown")]
    Unknown,

    [Description("User")]
    User,
}
