using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.InstanceFailoverGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstanceFailoverGroupReplicationRoleConstant
{
    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,
}
