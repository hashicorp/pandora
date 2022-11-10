using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRoleConstant
{
    [Description("AsyncReplica")]
    AsyncReplica,

    [Description("GeoAsyncReplica")]
    GeoAsyncReplica,

    [Description("GeoSyncReplica")]
    GeoSyncReplica,

    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,

    [Description("SyncReplica")]
    SyncReplica,

    [Description("WalReplica")]
    WalReplica,
}
