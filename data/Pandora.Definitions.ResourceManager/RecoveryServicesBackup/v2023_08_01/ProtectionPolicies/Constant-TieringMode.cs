using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.ProtectionPolicies;

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
