using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2022_01_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRoleConstant
{
    [Description("None")]
    None,

    [Description("Replica")]
    Replica,

    [Description("Source")]
    Source,
}
