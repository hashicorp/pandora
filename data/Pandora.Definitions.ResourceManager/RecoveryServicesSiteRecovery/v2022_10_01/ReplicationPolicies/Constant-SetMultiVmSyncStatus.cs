using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SetMultiVmSyncStatusConstant
{
    [Description("Disable")]
    Disable,

    [Description("Enable")]
    Enable,
}
