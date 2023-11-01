using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.FetchTieringCost;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPointTierTypeConstant
{
    [Description("ArchivedRP")]
    ArchivedRP,

    [Description("HardenedRP")]
    HardenedRP,

    [Description("InstantRP")]
    InstantRP,

    [Description("Invalid")]
    Invalid,
}
