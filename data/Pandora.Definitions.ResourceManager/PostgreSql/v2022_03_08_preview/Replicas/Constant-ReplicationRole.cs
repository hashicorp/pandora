using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRoleConstant
{
    [Description("AsyncReplica")]
    AsyncReplica,

    [Description("GeoAsyncReplica")]
    GeoAsyncReplica,

    [Description("None")]
    None,

    [Description("Primary")]
    Primary,
}
