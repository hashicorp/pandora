using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.GroupUser;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserStateConstant
{
    [Description("active")]
    Active,

    [Description("blocked")]
    Blocked,

    [Description("deleted")]
    Deleted,

    [Description("pending")]
    Pending,
}
