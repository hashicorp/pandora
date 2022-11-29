using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SetMultiVMSyncStatusConstant
{
    [Description("Disable")]
    Disable,

    [Description("Enable")]
    Enable,
}
