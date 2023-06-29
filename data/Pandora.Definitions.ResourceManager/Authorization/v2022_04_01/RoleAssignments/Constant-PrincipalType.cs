using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.RoleAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrincipalTypeConstant
{
    [Description("Device")]
    Device,

    [Description("ForeignGroup")]
    ForeignGroup,

    [Description("Group")]
    Group,

    [Description("ServicePrincipal")]
    ServicePrincipal,

    [Description("User")]
    User,
}
