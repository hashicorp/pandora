using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleEligibilityScheduleInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MemberTypeConstant
{
    [Description("Direct")]
    Direct,

    [Description("Group")]
    Group,

    [Description("Inherited")]
    Inherited,
}
