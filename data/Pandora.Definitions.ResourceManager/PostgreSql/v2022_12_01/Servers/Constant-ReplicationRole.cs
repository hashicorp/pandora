using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_12_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRoleConstant
{
    [Description("AsyncReplica")]
    AsyncReplica,

    [Description("GeoAsyncReplica")]
    GeoAsyncReplica,

    [Description("GeoSyncReplica")]
    GeoSyncReplica,

    [Description("None")]
    None,

    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,

    [Description("SyncReplica")]
    SyncReplica,

    [Description("WalReplica")]
    WalReplica,
}
