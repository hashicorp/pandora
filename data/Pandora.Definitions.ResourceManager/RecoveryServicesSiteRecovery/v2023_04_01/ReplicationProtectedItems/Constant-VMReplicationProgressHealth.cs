using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMReplicationProgressHealthConstant
{
    [Description("InProgress")]
    InProgress,

    [Description("NoProgress")]
    NoProgress,

    [Description("None")]
    None,

    [Description("SlowProgress")]
    SlowProgress,
}
