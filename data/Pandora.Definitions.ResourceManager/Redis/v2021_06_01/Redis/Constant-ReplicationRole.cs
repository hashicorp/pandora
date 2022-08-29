using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Redis.v2021_06_01.Redis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRoleConstant
{
    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,
}
