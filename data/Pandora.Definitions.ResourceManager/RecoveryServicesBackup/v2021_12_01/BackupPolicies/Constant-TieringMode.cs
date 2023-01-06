using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TieringModeConstant
{
    [Description("DoNotTier")]
    DoNotTier,

    [Description("Invalid")]
    Invalid,

    [Description("TierAfter")]
    TierAfter,

    [Description("TierRecommended")]
    TierRecommended,
}
