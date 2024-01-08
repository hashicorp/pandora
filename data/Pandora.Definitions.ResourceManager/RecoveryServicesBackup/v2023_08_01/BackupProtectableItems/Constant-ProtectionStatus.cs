using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.BackupProtectableItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtectionStatusConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("NotProtected")]
    NotProtected,

    [Description("Protected")]
    Protected,

    [Description("Protecting")]
    Protecting,

    [Description("ProtectionFailed")]
    ProtectionFailed,
}
