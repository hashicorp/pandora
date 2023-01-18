using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleAssignmentScheduleRequests;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("AfterDateTime")]
    AfterDateTime,

    [Description("AfterDuration")]
    AfterDuration,

    [Description("NoExpiration")]
    NoExpiration,
}
