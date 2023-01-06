using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupWorkloadItems;

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
