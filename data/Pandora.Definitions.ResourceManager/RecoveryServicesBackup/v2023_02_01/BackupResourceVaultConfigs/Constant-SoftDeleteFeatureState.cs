using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.BackupResourceVaultConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SoftDeleteFeatureStateConstant
{
    [Description("AlwaysON")]
    AlwaysON,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Invalid")]
    Invalid,
}
