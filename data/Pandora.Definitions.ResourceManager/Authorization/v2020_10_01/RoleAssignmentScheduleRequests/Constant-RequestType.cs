using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleAssignmentScheduleRequests;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RequestTypeConstant
{
    [Description("AdminAssign")]
    AdminAssign,

    [Description("AdminExtend")]
    AdminExtend,

    [Description("AdminRemove")]
    AdminRemove,

    [Description("AdminRenew")]
    AdminRenew,

    [Description("AdminUpdate")]
    AdminUpdate,

    [Description("SelfActivate")]
    SelfActivate,

    [Description("SelfDeactivate")]
    SelfDeactivate,

    [Description("SelfExtend")]
    SelfExtend,

    [Description("SelfRenew")]
    SelfRenew,
}
