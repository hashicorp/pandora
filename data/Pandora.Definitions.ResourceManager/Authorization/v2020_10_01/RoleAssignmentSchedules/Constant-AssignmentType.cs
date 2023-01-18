using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleAssignmentSchedules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssignmentTypeConstant
{
    [Description("Activated")]
    Activated,

    [Description("Assigned")]
    Assigned,
}
