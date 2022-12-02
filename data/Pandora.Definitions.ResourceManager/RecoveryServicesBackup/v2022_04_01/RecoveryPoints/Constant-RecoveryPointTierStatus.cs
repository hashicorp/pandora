using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.RecoveryPoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPointTierStatusConstant
{
    [Description("Deleted")]
    Deleted,

    [Description("Disabled")]
    Disabled,

    [Description("Invalid")]
    Invalid,

    [Description("Rehydrated")]
    Rehydrated,

    [Description("Valid")]
    Valid,
}
