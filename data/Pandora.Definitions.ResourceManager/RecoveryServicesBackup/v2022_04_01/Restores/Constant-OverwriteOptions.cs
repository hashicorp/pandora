using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.Restores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OverwriteOptionsConstant
{
    [Description("FailOnConflict")]
    FailOnConflict,

    [Description("Invalid")]
    Invalid,

    [Description("Overwrite")]
    Overwrite,
}
