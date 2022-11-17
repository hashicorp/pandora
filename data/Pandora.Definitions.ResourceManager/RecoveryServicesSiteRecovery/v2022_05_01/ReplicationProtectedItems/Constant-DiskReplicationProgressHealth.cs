using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskReplicationProgressHealthConstant
{
    [Description("InProgress")]
    InProgress,

    [Description("NoProgress")]
    NoProgress,

    [Description("None")]
    None,

    [Description("Queued")]
    Queued,

    [Description("SlowProgress")]
    SlowProgress,
}
