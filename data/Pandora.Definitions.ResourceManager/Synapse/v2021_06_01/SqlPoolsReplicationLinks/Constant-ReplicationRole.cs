using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsReplicationLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRoleConstant
{
    [Description("Copy")]
    Copy,

    [Description("NonReadableSecondary")]
    NonReadableSecondary,

    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,

    [Description("Source")]
    Source,
}
