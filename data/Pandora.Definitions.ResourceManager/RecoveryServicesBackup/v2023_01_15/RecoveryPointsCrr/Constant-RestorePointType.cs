using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.RecoveryPointsCrr;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RestorePointTypeConstant
{
    [Description("Differential")]
    Differential,

    [Description("Full")]
    Full,

    [Description("Incremental")]
    Incremental,

    [Description("Invalid")]
    Invalid,

    [Description("Log")]
    Log,
}
