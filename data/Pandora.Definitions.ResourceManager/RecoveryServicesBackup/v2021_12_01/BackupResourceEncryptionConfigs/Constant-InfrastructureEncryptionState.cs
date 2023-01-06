using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupResourceEncryptionConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InfrastructureEncryptionStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Invalid")]
    Invalid,
}
