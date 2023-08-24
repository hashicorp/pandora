using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityTypeConstant
{
    [Description("ConfidentialVM")]
    ConfidentialVM,

    [Description("None")]
    None,

    [Description("TrustedLaunch")]
    TrustedLaunch,
}
