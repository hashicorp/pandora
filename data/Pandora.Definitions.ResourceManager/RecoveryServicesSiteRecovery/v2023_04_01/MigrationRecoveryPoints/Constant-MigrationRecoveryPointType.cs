using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.MigrationRecoveryPoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationRecoveryPointTypeConstant
{
    [Description("ApplicationConsistent")]
    ApplicationConsistent,

    [Description("CrashConsistent")]
    CrashConsistent,

    [Description("NotSpecified")]
    NotSpecified,
}
