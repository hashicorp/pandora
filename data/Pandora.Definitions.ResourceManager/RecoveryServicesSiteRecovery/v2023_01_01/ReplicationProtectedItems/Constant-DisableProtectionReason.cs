using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_01_01.ReplicationProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DisableProtectionReasonConstant
{
    [Description("MigrationComplete")]
    MigrationComplete,

    [Description("NotSpecified")]
    NotSpecified,
}
